using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using Accord.MachineLearning.VectorMachines;
using Accord.Statistics.Kernels;
using Accord.MachineLearning.VectorMachines.Learning;
using System.Diagnostics;
using System.Globalization;
namespace VirusDetectionSystem
{
    public partial class FrmVDS : Form
    {
        bool isErrorDefaultComputingDL = false;
        bool isErrorFolderTesting = false;
        int mTime = 0;
        int mTime2 = 0;
        int mTime3 = 0;
        DataGridView dGVFolderTestingResult;

        int threadCount = 7;
        int LengthOfString=32;
        ThreadCell aThreadCell = new ThreadCell();
        BinaryString[] tvStrings;
        BinaryString[] benignStrings;
        Random _rd = new Random();
        public FrmVDS()
        {
            dGVFolderTestingResult = new DataGridView();
            this.dGVFolderTestingResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVFolderTestingResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVFolderTestingResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVFolderTestingResult.Location = new System.Drawing.Point(3, 3);
            this.dGVFolderTestingResult.Name = "dGVFolderTestingResult";
            this.dGVFolderTestingResult.Size = new System.Drawing.Size(650, 583);
            this.dGVFolderTestingResult.TabIndex = 0;
            this.dGVFolderTestingResult.Paint += new PaintEventHandler(dGVTestingResult_Paint_FolderTesting);
            InitializeComponent();
            //this.Text = "VDS - Cuoi cung" + Directory.GetCurrentDirectory();
            //this.Text = "-Virus Detection System-";
            txtMainDirectory.Text= Directory.GetCurrentDirectory();
        }
        /// <summary>
        /// A background worker performs ainet algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void backgroundWorkerAinet_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopElapsedTimer();
            if (e.Error != null)
            {
                
                WriteToStateNotification("aiNet has errors");
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                WriteToStateNotification("aiNet Completed");
            }
            EnableTraining();
        }
        void backgroundWorkerAinet_DoWork(object sender, DoWorkEventArgs e)
        {
            WriteToStateNotification("aiNet start");
            BackgroundWorker worker = sender as BackgroundWorker;
            string[] sampleStrs = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Virus.data");
            string[] detectorStrs = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Detectors.data");
            string[] benignStrings = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Benign.data");
            HashSet<BinaryString> virusSet = new HashSet<BinaryString>();
            HashSet<BinaryString> detectorSet = new HashSet<BinaryString>();
            HashSet<BinaryString> benignSet = new HashSet<BinaryString>();
            for (int i = 0; i < sampleStrs.Length; i++)
            {
                bool[] value = new bool[sampleStrs[i].Length];
                for (int j = 0; j < value.Length; j++)
                {
                    value[j] = (sampleStrs[i][j] == '1');
                }
                virusSet.Add(new BinaryString(value));
            }
            for (int i = 0; i < detectorStrs.Length; i++)
            {
                bool[] value = new bool[detectorStrs[i].Length];
                for (int j = 0; j < value.Length; j++)
                {
                    value[j] = (detectorStrs[i][j] == '1');
                }
                detectorSet.Add(new BinaryString(value));
            }
            for (int i = 0; i < benignStrings.Length; i++)
            {
                bool[] value = new bool[benignStrings[i].Length];
                for (int j = 0; j < value.Length; j++)
                {
                    value[j] = (benignStrings[i][j] == '1');
                }
                benignSet.Add(new BinaryString(value));
            }
            int size = detectorSet.Count;
            double suppression_thresold = (1-(double)nUDSupThreshold.Value);//0.1;
            double suppression_clone = suppression_thresold;/*(1-(double)nUDClonalSupThreshold.Value);//0.1;*/
            //double elimateclone_Thresold = (1-(double)nUDEleminateClonalThreshold.Value);//0.1;
            double elimateclone_Thresold = (1 - (double)nUDMatchingThresholdAiNet.Value);
            int cloneN = (int)nUDClonesNum_APattern.Value;//50;Number of random detectors are added to detectors in the next generation
            int maxGeneration = (int)numericUpDownGeneration.Value;
            int newRandomDetectors = (int)nUDNewRandomDetectors.Value;
            int matchingLength = (int)Math.Round(LengthOfString * (1 - (double)nUDMatchingThresholdAiNet.Value));
            List<HashSet<BinaryString>> innerDetectors = new List<HashSet<BinaryString>>();
            for (int i = 0; i < virusSet.Count; i++)
            {
                innerDetectors.Add(new HashSet<BinaryString>());
            }
            for (int generation = 0; generation < maxGeneration; generation++)
            {
                for (int sampleIndex = 0; sampleIndex < virusSet.Count; sampleIndex++)
                {
                    
                    BinaryString tvSample = virusSet.ElementAt(sampleIndex);
                    int selectedN = (int)nUDSelectedClonesNum.Value;
                    if (selectedN > detectorSet.Count)
                        selectedN = detectorSet.Count;
                    List<Detector_Aff> affs = new List<Detector_Aff>();
                    ComputingAff_DisThreadCell computingAff_DisCell = new ComputingAff_DisThreadCell();
                    computingAff_DisCell.Computing(detectorSet.ToList(), tvSample, 1000);
                    affs = computingAff_DisCell.Result;
                    affs = GetSelectedClones(affs, selectedN);
                   
                    affs = Clone(affs, cloneN);
                    for (int k = 0; k < affs.Count;)
                    {
                        if (affs[k].Distance / affs[k].Detector.Value.Length > elimateclone_Thresold)
                        {
                            affs.RemoveAt(k);
                        }
                        else
                            k++;
                    }

                    for (int i = 0; i < affs.Count - 1; )
                    {
                        int flag = 1;
                        for (int j = i + 1; j < affs.Count; )
                        {
                            double dis = MatchingMachine.GetHammingDis(affs[i].Detector, affs[j].Detector);
                            if (dis / affs[i].Detector.Value.Length < suppression_clone)
                            {
                                if (affs[i].Distance < affs[j].Distance)
                                {
                                    affs.RemoveAt(j);
                                }
                                else
                                {
                                    affs.RemoveAt(i);
                                    flag = 0;
                                    break;
                                }
                            }
                            else
                                j++;
                        }
                        i += flag;
                    }
     
                    HashSet<BinaryString> curDetecctor = new HashSet<BinaryString>();
                    for (int i = 0; i < affs.Count; i++)
                    {
                        curDetecctor.Add(affs[i].Detector);
                    }
                    innerDetectors[sampleIndex] = curDetecctor;
                }

                detectorSet.Clear();

                for (int i = 0; i < innerDetectors.Count; i++)
                {
                    detectorSet.UnionWith(innerDetectors[i]);
                }

                //WriteToStateNotification("\nExternal Suppression: detector:"+detectorSet.Count);
                WriteToStateNotificationWithoutNewLine("\tGeneration: " + (generation + 1) + ", Detectors Before External Suppression:" + detectorSet.Count);

                for (int i = 0; i < detectorSet.Count - 1; )
                {
                    int flag = 1;
                    for (int j = i + 1; j < detectorSet.Count; )
                    {
                        double dis = MatchingMachine.GetHammingDis(detectorSet.ElementAt(i), detectorSet.ElementAt(j));
                        if (dis / detectorSet.ElementAt(i).Value.Length < suppression_thresold)
                        {
                            detectorSet.Remove(detectorSet.ElementAt(j));
                        }
                        else
                            j++;
                    }
                    i += flag;
                }


                WriteToStateNotificationWithoutNewLine(", Detectors After External Suppression:" + detectorSet.Count);

                CleanThreadCell cleanThreadCell = new CleanThreadCell();
                cleanThreadCell.GlobalCleanXBasedOnY(detectorSet.ToList(), benignSet, matchingLength, threadCount);
                detectorSet = cleanThreadCell.CleanedSet;

                WriteToStateNotificationWithoutNewLine(", Detectors After Cleaning:" + detectorSet.Count + "\n");

                BinaryString rdDetector = new BinaryString();
                int rdI = 0;
                int rdCount = newRandomDetectors;

                if (generation < (maxGeneration - 1))
                {
                    while (rdI < rdCount)
                    {
                        rdDetector = new DetectorGenerator().GenerateADetector(LengthOfString);
                        detectorSet.Add(rdDetector);
                        rdI++;
                    }
                }
            }
            File.WriteAllText(@txtMainDirectory.Text + "\\" + "aiNet\\Detectors.data", "");
            foreach (var detector in detectorSet)
            {
                File.AppendAllText(@txtMainDirectory.Text + "\\" + "aiNet\\Detectors.data", detector.ToString() + "\n");
            }
            File.WriteAllText(@txtMainDirectory.Text + "\\" + "aiNetParameters.txt", "");
            File.AppendAllText(@txtMainDirectory.Text + "\\" + "aiNetParameters.txt", "MatchingThresholdAiNet: " + nUDMatchingThresholdAiNet.Value + "\n" + "SuppressionThreshold: " + nUDSupThreshold.Value);
            LoadAfteraiNet();
        }
        private List<Detector_Aff> GetSelectedClones(List<Detector_Aff> affs, int selectedN)
        {
            List<Detector_Aff> result = new List<Detector_Aff>();
            for (int j = 0; j < selectedN; j++)
            {
                int max = 0;
                for (int i = 1; i < affs.Count; i++)
                {
                    if (affs[i].Distance < affs[max].Distance)
                    {
                        max = i;
                    }
                }
                result.Add(affs[max]);
                affs.RemoveAt(max);
            }
            return result;
        }

        /// <summary>
        /// A background worker perform NSA algorithm after clustering step is finished
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void nsaWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
             stopElapsedTimer();
            if (e.Error != null)
            {

                WriteToStateNotification("Generating first detectors has errors");
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                WriteToStateNotification("Generating first detectors completed");
            }
                EnableTraining();
        }
        void nsaWorker_RunWorkerCompleted_Version2(object sender, RunWorkerCompletedEventArgs e)
        {
            stopElapsedTimer();
            if (e.Error != null)
            {

                WriteToStateNotification("Generating first detectors has errors");
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                WriteToStateNotification("Generating first detectors completed");
                MessageBox.Show("Running All First Steps finished");
            }
            EnableTraining();
            

        }
        void nsaWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            WriteToStateNotification("Generating first detectors start");

            HashSet<BinaryString> virusSet = new HashSet<BinaryString>();// Set virus' samples
            HashSet<BinaryString> benignSet = new HashSet<BinaryString>();//set of benign-file's sample

            string[] virusStrs = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "Cleaning\\Virus.data");
            string[] benignStrings = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "Cleaning\\Benign.data");

            for (int i = 0; i < virusStrs.Length; i++)
            {
                bool[] value = new bool[virusStrs[i].Length];
                for (int j = 0; j < value.Length; j++)
                {
                    value[j] = (virusStrs[i][j] == '1');
                }
                virusSet.Add(new BinaryString(value));
            }
            for (int i = 0; i < benignStrings.Length; i++)
            {
                bool[] value = new bool[benignStrings[i].Length];
                for (int j = 0; j < value.Length; j++)
                {
                    value[j] = (benignStrings[i][j] == '1');
                }
                benignSet.Add(new BinaryString(value));
            }

            int length = LengthOfString;
            int matchingThreshold = (int)Math.Round(LengthOfString * (1 - (double)nUDMatchingThreshold.Value));
            int nsaDetectorSetCount = (int)nUDNSADetectorCount.Value;
            int errorMax = (int)nUDMaxErrors.Value;

            HashSet<BinaryString> detectorSet = new HashSet<BinaryString>();//Detector set
            detectorSet.UnionWith(virusSet);
            if (virusSet.Count < nsaDetectorSetCount)
            {
                Random rd = new Random();
                int errorCount = 0;
                while (detectorSet.Count < nsaDetectorSetCount)
                {
                    int rdIndex = rd.Next(0, virusSet.Count);
                    DetectorGenerator detectorGenertor = new DetectorGenerator();
                    BinaryString newDetector = detectorGenertor.GenerateADetector(virusSet.ElementAt(rdIndex), matchingThreshold);
                    if (!detectorSet.Contains(newDetector))
                    {
                        bool isMatch = false;
                        foreach (var benign in benignSet)
                        {
                            if (MatchingMachine.HammingDisWithThreshold(benign, newDetector, matchingThreshold))
                            {
                                errorCount++;
                                isMatch = true;
                                break;
                            }
                        }
                        if (!isMatch)
                        {
                            detectorSet.Add(newDetector);
                            errorCount = 0;
                        }
                    }
                    else
                    {
                        errorCount++;
                    }
                    if (errorCount >= errorMax) break;
                }
            }

            WriteToStateNotification("Details: \n\tBenign:" + benignSet.Count + "\n\tVirus:" + virusSet.Count + "\n\tDetector:" + detectorSet.Count);
            //Write filtered virus genes into a file
            File.WriteAllText(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Benign.data", "");
            foreach (var benign in benignSet)
            {
                File.AppendAllText(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Benign.data", benign.ToString() + "\n");
            }

            //Write filtered virus genes into a file
            File.WriteAllText(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Virus.data", "");
            foreach (var sample in virusSet)
            {
                File.AppendAllText(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Virus.data", sample.ToString() + "\n");
            }
            //Write filtered detectors into a file
            File.WriteAllText(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Detectors.data", "");
            foreach (var detector in detectorSet)
            {
                File.AppendAllText(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Detectors.data", detector.ToString() + "\n");
            }
            File.WriteAllText(@txtMainDirectory.Text + "\\" + "GeneratingFirstDetectorsParameters.txt", "");
            File.AppendAllText(@txtMainDirectory.Text + "\\" + "GeneratingFirstDetectorsParameters.txt", "MatchingThreshold: " + nUDMatchingThreshold.Value + "\nNumber of detectors: " + (int)nUDNSADetectorCount.Value + "\nError Count: " + (int)nUDMaxErrors.Value);
            LoadAfterNSA();

        }

        /// <summary>
        /// A background worker call method of threadcell to cluster benign data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void benignWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            //WriteToStateNotification("Done Bengin Clustering!" + aThreadCell.BSet.Count);
            WriteToStateNotification("\tBengin Clustering completed");
        }
        void benignWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WriteToStateNotification("\tBenign Clustering start");
            aThreadCell.ProcessingBenignGenes(benignStrings, (LengthOfString * (1 - (double)nUDClusteringThreshold.Value)), (int)nUDLimitCountforDBSCAN.Value);

            File.WriteAllText(@txtMainDirectory.Text+"\\"+"Clustering\\Benign.data", "");
            foreach (var benign in aThreadCell.BSet)
            {
                File.AppendAllText(@txtMainDirectory.Text+"\\"+"Clustering\\Benign.data", benign.ToString() + "\n");
            }
        }

        /// <summary>
        /// A background worker call method of threadcell to cluster virus data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void virusWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //WriteToStateNotification("Done Virus Clustering! " + aThreadCell.VirusSet.Count);
            WriteToStateNotification("\tVirus Clustering completed");
        }
        void virusWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WriteToStateNotification("\tVirus Clustering start");
            aThreadCell.ProcessingVirusGenes(tvStrings, (LengthOfString * (1 - (double)nUDClusteringThreshold.Value)), (int)nUDLimitCountforDBSCAN.Value);
            File.WriteAllText(@txtMainDirectory.Text + "\\" + "Clustering\\Virus.data", "");
            foreach (var sample in aThreadCell.VirusSet)
            {
                File.AppendAllText(@txtMainDirectory.Text+"\\"+"Clustering\\Virus.data", sample.ToString() + "\n");
            }
        }


        private void btnaiNet_Click(object sender, EventArgs e)
        {
            startElapsedTimer();
            DisableTraining();
            BackgroundWorker backgroundWorkerAinet = new BackgroundWorker();
            backgroundWorkerAinet.DoWork += new DoWorkEventHandler(backgroundWorkerAinet_DoWork);
            backgroundWorkerAinet.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerAinet_RunWorkerCompleted);
            if (backgroundWorkerAinet.IsBusy != true)
            {
                backgroundWorkerAinet.RunWorkerAsync();
            }
        }
        private List<Detector_Aff> Clone(List<Detector_Aff> affs, int cloneN)
        {
            List<Detector_Aff> newAffs = new List<Detector_Aff>();
            HashSet<BinaryString> clonalDetectors = new HashSet<BinaryString>();
            foreach (var aff in affs)
            {
                clonalDetectors.Add(aff.Detector);
            }
            Random rd = new Random();
            for (int i = 0; i < affs.Count; i++)
            {
                if (affs[i].Distance != 0)
                {
                    double n = Math.Round((1 - affs[i].Distance / affs[i].Detector.Value.Length) * cloneN);
                    for (int j = 0; j < n; j++)
                    {
                        List<int> firstIndex = new List<int>();
                        for (int u = 0; u < affs[i].Detector.Value.Length; u++)
                        {
                            firstIndex.Add(u);
                        }
                        BinaryString clonalDetector = new BinaryString() { };
                        affs[i].Detector.Value.CopyTo(clonalDetector.Value, 0);
                        double mutationRate = (Math.Round(affs[i].Distance / 2)>0)?Math.Round(affs[i].Distance / 2):1;
                        List<int> rIndexs = new List<int>();
                        for (int k = 0; k < mutationRate; k++)
                        {
                            int index=0;
                            int tempIndex = 0;
                            tempIndex = rd.Next(0, firstIndex.Count);
                            index = firstIndex[tempIndex];
                            firstIndex.RemoveAt(tempIndex);
                            clonalDetector.Value[index] = !clonalDetector.Value[index];
                        }
                        clonalDetectors.Add(clonalDetector);
                        
                    }
                }
            }
            foreach (var detector in clonalDetectors)
            {
                Detector_Aff newDetector_Aff = new Detector_Aff();
                newDetector_Aff.Detector=detector;
                newDetector_Aff.Sample=affs[0].Sample;
                newDetector_Aff.Distance=MatchingMachine.GetHammingDis(detector,newDetector_Aff.Sample);
                newAffs.Add(newDetector_Aff);
            }
            return newAffs;
        }
        
        private List<Detector_Aff> SortDecreaseAff(List<Detector_Aff> affs)
        {
            
            for (int i=0; i < affs.Count-1; i++)
            {
                int m=i;
                for (int j = i+1; j < affs.Count; j++)
                {
                    if (affs[m].Distance > affs[j].Distance)
                    {
                        m = j;
                    }
                }
                Detector_Aff temp=affs[i];
                affs[i]=affs[m];
                affs[m]=temp;
            }
            return affs;
        }
        private void btnRunNSA_Click(object sender, EventArgs e)
        {
            startElapsedTimer();
            DisableTraining();
            BackgroundWorker clusteringWorker = new BackgroundWorker();
            clusteringWorker.DoWork += new DoWorkEventHandler(clusteringWorker_DoWork);
            clusteringWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(clusteringWorker_RunWorkerCompleted_Version2);
            clusteringWorker.RunWorkerAsync();
            
        }

        private void btnComputingLD_Click(object sender, EventArgs e)
        {
            //DisableComputingLD();
            startElapsedTimer2();
            DisableClassification();
            BackgroundWorker workerComputingLD = new BackgroundWorker();
            workerComputingLD.DoWork += new DoWorkEventHandler(workerComputingLD_DoWork);
            workerComputingLD.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerComputingLD_RunWorkerCompleted);
            workerComputingLD.RunWorkerAsync();
        }
        void workerComputingLD_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopElapsedTimer2();
            if (e.Error != null)
                MessageBox.Show(e.Error.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
                MessageBox.Show("Computing danger levels completed");
            EnableClassification();
        }
        void DisableComputingLD()
        {
            gBDangerLevel.Enabled = false;
        }
        void EnableComputingLD()
        {
            gBDangerLevel.Enabled = true;
        }
        void workerComputingLD_DoWork(object sender, DoWorkEventArgs e)
        {
            
                this.Invoke((MethodInvoker)delegate { dGVDangerOfLevel.DataSource = null; });

                int label = (rdVirus.Checked == true) ? -1 : 1;

                HashSet<BinaryString> detectors = new HashSet<BinaryString>();
                string[] detectorStrs = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "aiNet\\detectors.data");
                for (int i = 0; i < detectorStrs.Length; i++)
                {
                    bool[] value = new bool[detectorStrs[i].Length];
                    for (int j = 0; j < value.Length; j++)
                    {
                        value[j] = (detectorStrs[i][j] == '1');
                    }
                    detectors.Add(new BinaryString(value));
                }
                List<LD> ldList = ComputingDLOfFolder(txtSourceLD.Text, txtDestinationLD.Text, detectors, label);

                DataTable table = new DataTable();
                table.Columns.Add("No.");
                table.Columns.Add("File");
                table.Columns.Add("HA");
                table.Columns.Add("RCBA12");
                table.Columns.Add("RCBA24");
                table.Columns.Add("Label");
                int no = 1;
                foreach (var ld in ldList)
                {
                    table.Rows.Add((no++).ToString(), ld.FileName, ld.HA, ld.RCBA12, ld.RCBA24, label == -1 ? "Virus(-1)" : "Benign(1)");
                }
                this.Invoke((MethodInvoker)delegate { dGVDangerOfLevel.DataSource = table; });
           
        }

        private List<LD> ComputingDLOfFolder(string source, string dest, HashSet<BinaryString> detectors, int label)
        {
            
            
            List<LD> ldList = new List<LD>();
            DirectoryInfo di = new DirectoryInfo(@source);
            DangerLevelThreadCell dangerLevelCell = new DangerLevelThreadCell();
            dangerLevelCell.ComputingDangerLevels(di.GetFiles().ToList(), detectors, threadCount);
            ldList = dangerLevelCell.DangerLevels;

            File.WriteAllText(@dest, "");
            for (int i = 0; i < ldList.Count; i++)
            {
                File.AppendAllText(@dest, ldList[i].FileName+":"+  ldList[i].HA.ToString(CultureInfo.InvariantCulture) + ":" + ldList[i].RCBA12.ToString(CultureInfo.InvariantCulture) + ":" + ldList[i].RCBA24.ToString(CultureInfo.InvariantCulture) + ":" + label + "\n");
            }
            return ldList;
        }

        private int GetMRD(BinaryString currGene, BinaryString detector, int r)
        {
            return GetRB(currGene, detector, r);
        }
        private double GetHM(BinaryString item1, BinaryString item2)
        {
            return MatchingMachine.GetHammingAff(item1,item2);
        }
        private int GetRB(BinaryString item1, BinaryString item2,int threshold)
        {
            BinaryString result = new BinaryString(new bool[item1.Value.Length]);
            for (int i = 0; i < item1.Value.Length; i++)
            {
                result.Value[i] = (item1.Value[i] == item2.Value[i]);
            }
            int count = 0;
            int max = 0;
            for (int i = 1; i < result.Value.Length; i++)
            {
                if (result.Value[i])
                    count++;
                else
                {
                    if (count > max)
                        max = count;
                    count = 0;
                }
            }
            if (max >= threshold)
                return 1;
            else
                return 0;
        }
        private HashSet<BinaryString> GetRelevantDetectors(BinaryString currGene, HashSet<BinaryString> detectors)
        {
            return detectors;
        }
        private int GetAff(string str1, string str2)
        {
            StringBuilder result = new StringBuilder("");
            int count = 0;
            for (int j = 0; j < str1.Length; j++)
            {
                if (str2[j] == str1[j])
                {
                    result.Append('1');
                }
                else
                    result.Append('0');
            }
            for (int j = 0; j < result.Length; j++)
            {
                if (result[j] == '1')
                {
                    count++;
                }
            }
            return count;
        }
        
        private void btnClassification_Click(object sender, EventArgs e)
        {
            startElapsedTimer2();
            DisableClassification();
            BackgroundWorker workerClassification = new BackgroundWorker();
            workerClassification.WorkerReportsProgress = true;
            workerClassification.WorkerSupportsCancellation = true;
            workerClassification.DoWork += new DoWorkEventHandler(workerClassification_DoWork);
            workerClassification.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerClassification_RunWorkerCompleted);
            workerClassification.RunWorkerAsync();
        }

        /// <summary>
        /// A background worker excutes classifier SVM to create model used to test
        /// </summary>
        /// <param name="sender">Background worker call this method</param>
        /// <param name="e">An eventarg contains states of the background worker</param>
        void workerClassification_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopElapsedTimer2();
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Classification completed");
            EnableClassification();
        }
        void workerClassification_DoWork(object sender, DoWorkEventArgs e)
        {
           
                string source = @txtMainDirectory.Text + "\\" + "Classification\\Training\\Model.txt";
                string des = @txtMainDirectory.Text + "\\" + "Classification\\Training\\Model.md";
                double[][] inputs;
                int[] labels;
                string[] filename;
                string[] inputStr = File.ReadAllLines(@source);
                inputs = new double[inputStr.Length][];
                labels = new int[inputStr.Length];
                filename = new string[inputStr.Length];
                for (int i = 0; i < inputStr.Length; i++)
                {
                    string[] values = inputStr[i].Split(':');
                    filename[i] = values[0];
                    inputs[i] = new double[] { Double.Parse(values[1], CultureInfo.InvariantCulture), Double.Parse(values[2], CultureInfo.InvariantCulture), Double.Parse(values[3], CultureInfo.InvariantCulture) };
                    labels[i] = Int32.Parse(values[4]);
                }
                bool scaleState=ComputingScalingAndSavePara(inputs);
                
                if (scaleState == false)
                {
                    throw new Exception("All vector of danger level are the same");
                }
                else
                {
                    inputs = Scaling(inputs);
                    KernelSupportVectorMachine machine = new KernelSupportVectorMachine(new Gaussian((double)nUDGuassKernelPara.Value), inputs[0].Length);
                    SequentialMinimalOptimization learn = new SequentialMinimalOptimization(machine, inputs, labels);

                    learn.Run();
                    machine.Save(@des);
                    File.WriteAllText(@txtMainDirectory.Text + "\\" + "KernelSigma.txt", "");
                    File.AppendAllText(@txtMainDirectory.Text + "\\" + "KernelSigma.txt", "Kernel Sigma: " + nUDGuassKernelPara.Value.ToString(CultureInfo.InvariantCulture));
                }
            
        }

        public double[][] Scaling(List<LD> inputs)
        {
            double[][] newInputs = new double[inputs.Count][];

            int tempIndex = 0;
            foreach (var row in inputs)
            {
                double[] temp = new double[3];
                temp[0] = row.HA;
                temp[1] = row.RCBA12;
                temp[2] = row.RCBA24;
                newInputs[tempIndex] = temp;
                tempIndex++;
            }

            return Scaling(newInputs);
        }
        public double[][] Scaling(double[][] inputs)
        {
            string[] para = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "ScalingParameters.txt");
            string[] maxStr = para[0].Split(':');
            string[] minStr = para[1].Split(':');
            double[] max = new double[maxStr.Length];
            for (int i = 0; i < maxStr.Length; i++)
            {
                max[i] = Double.Parse(maxStr[i], CultureInfo.InvariantCulture);
            }
            double[] min = new double[minStr.Length];
            for (int i = 0; i < minStr.Length; i++)
            {
                min[i] = Double.Parse(minStr[i], CultureInfo.InvariantCulture);
            }
            double[][] outputs = new double[inputs.Length][];
            int error = 0;
            for (int i = 0; i < max.Length; i++)
            {
                if (max[i] <= min[i]) error += 1;
            }
            if (error == inputs[0].Length) return null;
            int tempIndex = 0;
            foreach (var row in inputs)
            {
                double[] newValue = new double[row.Length - error];
                int j = 0;
                for (int i = 0; i < row.Length; i++)
                {
                    if (max[i] > min[i])
                    {
                        newValue[j] = (row[i] - min[i]) / (max[i] - min[i]);
                        j++;
                    }
                }
                outputs[tempIndex] = newValue;
                tempIndex++;
            }
            return outputs;
        }
        public bool ComputingScalingAndSavePara(double[][] inputs)
        {
            double[] max = new double[3];
            double[] min = new double[3];

            max[0] = inputs[0][0];
            max[1] = inputs[0][1];
            max[2] = inputs[0][2];

            min[0] = inputs[0][0];
            min[1] = inputs[0][1];
            min[2] = inputs[0][2];

            for (int i = 0; i < inputs.Length; i++)
            {
                if (max[0] < inputs[i][0]) max[0] = inputs[i][0];
                if (max[1] < inputs[i][1]) max[1] = inputs[i][1];
                if (max[2] < inputs[i][2]) max[2] = inputs[i][2];
                if (min[0] > inputs[i][0]) min[0] = inputs[i][0];
                if (min[1] > inputs[i][1]) min[1] = inputs[i][1];
                if (min[2] > inputs[i][2]) min[2] = inputs[i][2];
            }

            int error = 0;
            for (int i = 0; i < max.Length; i++)
            {
                if (max[i] <= min[i]) error += 1;
            }
            if (error == inputs[0].Length) return false;
            File.WriteAllText(@txtMainDirectory.Text + "\\" + "ScalingParameters.txt", "");
            File.AppendAllText(@txtMainDirectory.Text + "\\" + "ScalingParameters.txt", max[0].ToString(CultureInfo.InvariantCulture) + ":" + max[1].ToString(CultureInfo.InvariantCulture) + ":" + max[2].ToString(CultureInfo.InvariantCulture));
            File.AppendAllText(@txtMainDirectory.Text + "\\" + "ScalingParameters.txt", "\n");
            File.AppendAllText(@txtMainDirectory.Text + "\\" + "ScalingParameters.txt", min[0].ToString(CultureInfo.InvariantCulture) + ":" + min[1].ToString(CultureInfo.InvariantCulture) + ":" + min[2].ToString(CultureInfo.InvariantCulture));
            return true;
        }
        private void btnTestModel_Click(object sender, EventArgs e)
        {
            //isErrorFileTesting = false;
            
            isErrorFolderTesting = false;
            SetPredictingResultToDefault();
            try
            {
                //string modelFile = txtModelFile.Text;
                startElapsedTimer3();
                if (rdDangerLevelFileTesting.Checked == true)
                {
                    
                    string modelFile = @txtMainDirectory.Text + "\\" + "Classification\\Training\\Model.md";
                    KernelSupportVectorMachine machine = KernelSupportVectorMachine.Load(@modelFile);
                    this.tabPage5.Controls.Remove(this.dGVFolderTestingResult);
                    this.tabPage5.Controls.Add(this.dGVTestingResult);
                    dGVTestingResult.DataSource = null;
                    string testFile = txtTestFile.Text;
                    double[][] inputs;
                    double[][] newInputs;
                    int[] labels;
                    string[] filename;
                    string[] inputStr = File.ReadAllLines(@testFile);
                    inputs = new double[inputStr.Length][];
                    newInputs = new double[inputStr.Length][];
                    labels = new int[inputStr.Length];
                    filename=new string[inputStr.Length];
                    for (int i = 0; i < inputStr.Length; i++)
                    {
                        string[] values = inputStr[i].Split(':');
                        filename[i] = values[0];
                        inputs[i] = new double[] { Double.Parse(values[1], CultureInfo.InvariantCulture), Double.Parse(values[2], CultureInfo.InvariantCulture), Double.Parse(values[3], CultureInfo.InvariantCulture) };
                        newInputs[i] = new double[] { Double.Parse(values[1], CultureInfo.InvariantCulture), Double.Parse(values[2], CultureInfo.InvariantCulture), Double.Parse(values[3], CultureInfo.InvariantCulture) };
                        labels[i] = Int32.Parse(values[4]);
                    }

                    newInputs = Scaling(newInputs);
                    if (newInputs == null)
                    {
                        stopElapsedTimer3();
                        MessageBox.Show("Scaling parameters have problem", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int correct = 0;
                        int wrong = 0;
                        DataTable dangerLevelFileTestingTable = new DataTable();
                        dangerLevelFileTestingTable.Columns.Add("No.");
                        dangerLevelFileTestingTable.Columns.Add("File");
                        dangerLevelFileTestingTable.Columns.Add("HA");
                        dangerLevelFileTestingTable.Columns.Add("RCBA12");
                        dangerLevelFileTestingTable.Columns.Add("RCBA24");
                        dangerLevelFileTestingTable.Columns.Add("Input Label");
                        dangerLevelFileTestingTable.Columns.Add("Predicted Label");

                        for (int i = 0; i < inputs.Length; i++)
                        {
                            int sign = Math.Sign(machine.Compute(newInputs[i]));
                            if (sign == 0) sign = -1;//new
                            if (Math.Sign(labels[i]) == sign)
                            {
                                correct++;
                            }
                            else
                            {
                                wrong++;
                            }
                            dangerLevelFileTestingTable.Rows.Add(i + 1, filename[i], inputs[i][0], inputs[i][1], inputs[i][2], (labels[i] == 1 ? "Benign" : "Virus"), (sign == 1 ? "Benign" : "Virus"));
                        }

                        lbCorrectTestCount.Text = correct.ToString();
                        lbWrongTestCount.Text = wrong.ToString();
                        lbBenignCount_TestModel.Text = "---";
                        lbVirusCount_TestModel.Text = "---";
                        lbRateFileTesting.Text = (Math.Round(((double)correct) / (correct + wrong), 6) * 100).ToString() + "%";



                        if (File.Exists(@txtMainDirectory.Text + "\\" + "DLFileTestingResults.txt"))
                        {
                            //if (File.ReadAllLines("FileTestingResults.txt").Length >= 2) File.WriteAllText("FileTestingResults.txt", "");
                            File.AppendAllText(@txtMainDirectory.Text + "\\" + "DLFileTestingResults.txt", testFile + ": (" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToShortDateString() + ") " + correct + "/" + (correct + wrong) + " " + lbRateFileTesting.Text + "\n");
                        }
                        else
                        {
                            File.WriteAllText(@txtMainDirectory.Text + "\\" + "DLFileTestingResults.txt", "");
                            File.AppendAllText(@txtMainDirectory.Text + "\\" + "DLFileTestingResults.txt", testFile + ": (" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToShortDateString() + ") " + correct + "/" + (correct + wrong) + " " + lbRateFileTesting.Text + "\n");
                        }

                        dGVTestingResult.DataSource = dangerLevelFileTestingTable;
                        stopElapsedTimer3();
                        MessageBox.Show("Testing the file of danger level completed");
                    }
                }
                if (rdFolderTesting.Checked == true)
                {
                    DisableTestInformation();
                    BackgroundWorker folderTestingWorker = new BackgroundWorker();
                    folderTestingWorker.DoWork += new DoWorkEventHandler(folderTestingWorker_DoWork);
                    folderTestingWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(folderTestingWorker_RunWorkerCompleted);
                    folderTestingWorker.RunWorkerAsync();
                }
            }
            catch (Exception g)
            {
                stopElapsedTimer3();
                MessageBox.Show(g.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void SetPredictingResultToDefault()
        {
          
                lbCorrectTestCount.Text = "---";
                lbWrongTestCount.Text = "---";
                lbRateFileTesting.Text = "---";
                lbVirusCount_TestModel.Text = "---";
                lbBenignCount_TestModel.Text = "---";


        }
        void folderTestingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopElapsedTimer3();
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Testing the folder completed");
            EnableTestInformation();
        }

        void dGVTestingResult_Paint_FileTesting(object sender, PaintEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.DataSource != null)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells["Input Label"].Value != null && row.Cells["Predicted Label"].Value != null)
                    {
                        if (row.Cells["Input Label"].Value.ToString().CompareTo(row.Cells["Predicted Label"].Value.ToString()) != 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
            }
        }
        void dGVTestingResult_Paint_FolderTesting(object sender, PaintEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.DataSource != null)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells["Predicted Label"].Value != null)
                    {
                        if (row.Cells["Predicted Label"].Value.ToString().CompareTo("Virus") == 0)
                        {
                            row.DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }
        void DisableTestInformation()
        {
            //lbTestStatus.Text = "Performing...Please wait.";
            gBTestInformation.Enabled = false;
        }
        void EnableTestInformation()
        {
            //lbTestStatus.Text = "...";
            gBTestInformation.Enabled = true;
        }
        void folderTestingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
                
                //string modelFile = txtModelFile.Text;
                string modelFile = @txtMainDirectory.Text + "\\" + "Classification\\Training\\Model.md";
                string testingFolder = txtTestingFolder.Text;
                KernelSupportVectorMachine machine = KernelSupportVectorMachine.Load(@modelFile);

                this.Invoke((MethodInvoker)delegate { dGVFolderTestingResult.DataSource = null; this.tabPage5.Controls.Remove(this.dGVTestingResult); this.tabPage5.Controls.Add(this.dGVFolderTestingResult); });
                HashSet<BinaryString> detectors = new HashSet<BinaryString>();
                string[] detectorStrs = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "aiNet\\Detectors.data");
                for (int i = 0; i < detectorStrs.Length; i++)
                {
                    bool[] value = new bool[detectorStrs[i].Length];
                    for (int j = 0; j < value.Length; j++)
                    {
                        value[j] = (detectorStrs[i][j] == '1');
                    }
                    detectors.Add(new BinaryString(value));
                }
                List<LD> ldList = new List<LD>();
                DirectoryInfo di = new DirectoryInfo(testingFolder);
                DangerLevelThreadCell dangerLevelCell = new DangerLevelThreadCell();
                dangerLevelCell.ComputingDangerLevels(di.GetFiles().ToList(), detectors, threadCount);
                ldList = dangerLevelCell.DangerLevels;
                //List<LD> olddlList = new List<LD>();
                //foreach (var dl in ldList)
                //{
                //    olddlList.Add(new LD() { FileName=dl.FileName,HA=dl.HA,RCBA12=dl.RCBA12,RCBA24=dl.RCBA24 });
                //}

                //ldList = Scaling(ldList);
                double[][] newInputs = Scaling(ldList);
                //
                if (newInputs == null)
                {
                    throw new Exception("Scaling parameter have problems");
                }
                else
                {
                    DataTable dangerLevelFileTestingTable = new DataTable();
                    dangerLevelFileTestingTable.Columns.Add("No.");
                    dangerLevelFileTestingTable.Columns.Add("File");
                    dangerLevelFileTestingTable.Columns.Add("Predicted Label");

                    int virusCount = 0;
                    int benignCount = 0;

                    for (int i = 0; i < ldList.Count; i++)
                    {
                        //double[] dangerLevelOfFile = new double[] { ldList[i].HA, ldList[i].RCBA12, ldList[i].RCBA24 };
                        double[] dangerLevelOfFile = newInputs[i];
                        int sign = Math.Sign(machine.Compute(dangerLevelOfFile));
                        if (sign == 0) sign = -1;//new
                        dangerLevelFileTestingTable.Rows.Add(i + 1, ldList[i].FileName, (sign == 1 ? "Benign" : "Virus"));
                        if (sign == -1)
                        {
                            virusCount++;
                        }
                        else
                        {
                            benignCount++;
                        }
                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        dGVFolderTestingResult.DataSource = dangerLevelFileTestingTable;
                        lbBenignCount_TestModel.Text = benignCount.ToString();
                        lbVirusCount_TestModel.Text = virusCount.ToString();
                        lbCorrectTestCount.Text = "---";
                        lbWrongTestCount.Text = "---";
                        lbRateFileTesting.Text = "---";
                        EnableTestInformation();
                    });
                }
           
        }
        private void WriteToStateNotification(string msg)
        {
            this.Invoke((MethodInvoker)delegate { rTBStates.Text += msg + "\n"; rTBStates.Select(rTBStates.Text.Length - 1, 0); rTBStates.ScrollToCaret(); });
        }
        private void ClearStateNotification(string msg)
        {
            this.Invoke((MethodInvoker)delegate { rTBStates.Text=msg; });
        }
        private void WriteToStateNotificationWithoutNewLine(string msg)
        {
            this.Invoke((MethodInvoker)delegate { rTBStates.Text += msg; rTBStates.Select(rTBStates.Text.Length - 1, 0); rTBStates.ScrollToCaret(); });
        }
        private void btnOnlyNSA_Click(object sender, EventArgs e)
        {
            startElapsedTimer();
            DisableTraining();
            BackgroundWorker nsaWorker = new BackgroundWorker();
            nsaWorker.DoWork += new DoWorkEventHandler(nsaWorker_DoWork);
            nsaWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(nsaWorker_RunWorkerCompleted);
            nsaWorker.RunWorkerAsync();
        }

        private void btnComputingDLDefault_Click(object sender, EventArgs e)
        {
            startElapsedTimer2();
            //DisableComputingLD();
            DisableClassification();
            BackgroundWorker computingDLDefaultWorker = new BackgroundWorker();
            computingDLDefaultWorker.DoWork += new DoWorkEventHandler(computingDLDefaultWorker_DoWork);
            computingDLDefaultWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(computingDLDefaultWorker_RunWorkerCompleted);
            //MessageBox.Show("Computing Danger Levels of test");
            computingDLDefaultWorker.RunWorkerAsync();
        }

        void computingDLDefaultWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopElapsedTimer2();
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else    
                MessageBox.Show("Computing of danger levels of test completed");
            EnableClassification();
        }

        void computingDLDefaultWorker_DoWork(object sender, DoWorkEventArgs e)
        {

                HashSet<BinaryString> detectors = new HashSet<BinaryString>();
                string[] detectorStrs = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "aiNet\\detectors.data");
                for (int i = 0; i < detectorStrs.Length; i++)
                {
                    bool[] value = new bool[detectorStrs[i].Length];
                    for (int j = 0; j < value.Length; j++)
                    {
                        value[j] = (detectorStrs[i][j] == '1');
                    }
                    detectors.Add(new BinaryString(value));
                }
                ComputingDLOfFolder(@txtMainDirectory.Text + "\\" + "Classification\\Test\\Virusfiles", @txtMainDirectory.Text + "\\" + "Classification\\Test\\Virus.txt", detectors, -1);
                ComputingDLOfFolder(@txtMainDirectory.Text + "\\" + "Classification\\Test\\Benignfiles", @txtMainDirectory.Text + "\\" + "classification\\test\\Benign.txt", detectors, 1);
        }

        private void btnClustering_Click(object sender, EventArgs e)
        {
            startElapsedTimer();
            DisableTraining();
            BackgroundWorker clusteringWorker = new BackgroundWorker();
            clusteringWorker.DoWork += new DoWorkEventHandler(clusteringWorker_DoWork);
            clusteringWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(clusteringWorker_RunWorkerCompleted);
            clusteringWorker.RunWorkerAsync();
        }

        void DisableTraining()
        {
            this.Invoke((MethodInvoker)delegate
            {
                gBDirectory.Enabled = false;
                gBGenerateFirstDetectors.Enabled = false;
                gBAiNet.Enabled = false;
            });
            gBDirectory.Enabled = false;
            gBGenerateFirstDetectors.Enabled = false;
            gBAiNet.Enabled = false;
        }
        void EnableTraining()
        {
            this.Invoke((MethodInvoker)delegate
            {
                gBGenerateFirstDetectors.Enabled = true;
                gBAiNet.Enabled = true;
                gBDirectory.Enabled = true;
            });
            
        }

        void clusteringWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopElapsedTimer();
            if (e.Error != null)
            {

                WriteToStateNotification("Clustering has errors");
                MessageBox.Show(e.Error.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                WriteToStateNotification("Clustering completed");
            }
            EnableTraining();

        }
        void clusteringWorker_RunWorkerCompleted_Version2(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                WriteToStateNotification("Clustering has errors");
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableTraining();
            }
            else
            {
                WriteToStateNotification("Clustering completed");
                BackgroundWorker cleaningWorker = new BackgroundWorker();
                cleaningWorker.DoWork += new DoWorkEventHandler(cleaningWorker_DoWork);
                cleaningWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(cleaningWorker_RunWorkerCompleted_Version2);
                cleaningWorker.RunWorkerAsync();
            }
        }
        void clusteringWorker_DoWork(object sender, DoWorkEventArgs e)
        {
                WriteToStateNotification("Clustering start");
                BackgroundWorker worker = sender as BackgroundWorker;
                HashSet<BinaryString> tvGeneSet = new HashSet<BinaryString>();//Set of virus genes that are read from virus files
                DirectoryInfo di = new DirectoryInfo(@txtMainDirectory.Text + "\\" + "Training\\VirusFiles");
                foreach (var fi in di.GetFiles())
                {
                    byte[] binaryArray = null;
                    binaryArray = File.ReadAllBytes(fi.FullName);
                    for (int i = 0; i < binaryArray.Length / 2 - 4; i++)
                    {
                        Gene gene = new Gene();
                        Array.Copy(binaryArray, i * 2, gene.ByteGene, 0, 4);
                        tvGeneSet.Add(new BinaryString(gene.ToBools()));
                    }
                }
                WriteToStateNotification("\tVirus Genes from files:" + tvGeneSet.Count);
                HashSet<BinaryString> bGeneSet = new HashSet<BinaryString>();//Set of benign genes that are read from benign files

                di = new DirectoryInfo(@txtMainDirectory.Text + "\\" + "Training\\BenignFiles");
                foreach (var fi in di.GetFiles())
                {
                    byte[] binaryArray = null;
                    binaryArray = File.ReadAllBytes(fi.FullName);
                    for (int i = 0; i < binaryArray.Length / 2 - 4; i++)
                    {
                        Gene gene = new Gene();
                        Array.Copy(binaryArray, i * 2, gene.ByteGene, 0, 4);
                        bGeneSet.Add(new BinaryString(gene.ToBools()));
                    }
                }
                WriteToStateNotification("\tBenign Genes from files:" + bGeneSet.Count);
                tvStrings = tvGeneSet.ToArray();
                benignStrings = bGeneSet.ToArray();

                BackgroundWorker virusWorker = new BackgroundWorker();

                virusWorker.WorkerReportsProgress = true;
                virusWorker.WorkerSupportsCancellation = true;
                virusWorker.DoWork += new DoWorkEventHandler(virusWorker_DoWork);
                virusWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(virusWorker_RunWorkerCompleted);

                BackgroundWorker benignWorker = new BackgroundWorker();
                benignWorker.WorkerReportsProgress = true;
                benignWorker.WorkerSupportsCancellation = true;
                benignWorker.DoWork += new DoWorkEventHandler(benignWorker_DoWork);
                benignWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(benignWorker_RunWorkerCompleted);

                if (virusWorker.IsBusy != true)
                {
                    virusWorker.RunWorkerAsync();
                }
                if (benignWorker.IsBusy != true)
                {
                    benignWorker.RunWorkerAsync();
                }

                while (true)
                {
                    if (benignWorker.IsBusy != true && virusWorker.IsBusy != true)
                        break;
                }
                File.WriteAllText(@txtMainDirectory.Text + "\\" + "ClusteringParameters.txt", "");
                File.AppendAllText(@txtMainDirectory.Text + "\\" + "ClusteringParameters.txt", "Clustering Threshold: " + nUDClusteringThreshold.Value + "\n" + "Limit Count For DBSCAN: " + nUDLimitCountforDBSCAN.Value);
                LoadAfterClustering();
        }

        private void btnCleanVirusGeneSet_Click(object sender, EventArgs e)
        {
            startElapsedTimer();
            DisableTraining();
            BackgroundWorker cleaningWorker = new BackgroundWorker();
            cleaningWorker.DoWork += new DoWorkEventHandler(cleaningWorker_DoWork);
            cleaningWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(cleaningWorker_RunWorkerCompleted);
            cleaningWorker.RunWorkerAsync();
        }

        void cleaningWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                stopElapsedTimer();
            if (e.Error != null)
            {

                WriteToStateNotification("Cleaning of virus gene set has errors");
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                WriteToStateNotification("Cleaning of virus gene set completed");
            }
                EnableTraining();
        }
        void cleaningWorker_RunWorkerCompleted_Version2(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {

                WriteToStateNotification("Cleaning of virus gene set has errors");
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableTraining();
            }
            else
            {
                WriteToStateNotification("Cleaning of virus gene set completed");
                BackgroundWorker nsaWorker = new BackgroundWorker();
                nsaWorker.DoWork += new DoWorkEventHandler(nsaWorker_DoWork);
                nsaWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(nsaWorker_RunWorkerCompleted_Version2);
                nsaWorker.RunWorkerAsync();
            }
        }


        void cleaningWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            WriteToStateNotification("Cleaning of virus gene set start");
            HashSet<BinaryString> virusSet = new HashSet<BinaryString>();// Set virus' samples
            HashSet<BinaryString> benignSet = new HashSet<BinaryString>();//set of benign-file's sample

            string[] sampleStrs = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "Clustering\\Virus.data");
            string[] benignStrings = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "Clustering\\Benign.data");

            for (int i = 0; i < sampleStrs.Length; i++)
            {
                bool[] value = new bool[sampleStrs[i].Length];
                for (int j = 0; j < value.Length; j++)
                {
                    value[j] = (sampleStrs[i][j] == '1');
                }
                virusSet.Add(new BinaryString(value));
            }
            for (int i = 0; i < benignStrings.Length; i++)
            {
                bool[] value = new bool[benignStrings[i].Length];
                for (int j = 0; j < value.Length; j++)
                {
                    value[j] = (benignStrings[i][j] == '1');
                }
                benignSet.Add(new BinaryString(value));
            }

            int length = LengthOfString;
            int matchingThreshold = (int)Math.Round(LengthOfString * (1 - (double)nUDMatchingThreshold.Value));
            //Remove benign genes that are in virus genes
            CleanThreadCell cleanThreadCell = new CleanThreadCell();
            cleanThreadCell.GlobalCleanXBasedOnY(virusSet.ToList(), benignSet, matchingThreshold, threadCount);
            virusSet = cleanThreadCell.CleanedSet;

            File.WriteAllText(@txtMainDirectory.Text + "\\" + "Cleaning\\Virus.data", "");
            foreach (var sample in virusSet)
            {
                File.AppendAllText(@txtMainDirectory.Text + "\\" + "Cleaning\\Virus.data", sample.ToString() + "\n");
            }
            File.WriteAllText(@txtMainDirectory.Text + "\\" + "Cleaning\\Benign.data", "");
            foreach (var benign in benignSet)
            {
                File.AppendAllText(@txtMainDirectory.Text + "\\" + "Cleaning\\Benign.data", benign.ToString() + "\n");
            }
            File.WriteAllText(@txtMainDirectory.Text + "\\" + "CleaningParameters.txt", "");
            File.AppendAllText(@txtMainDirectory.Text + "\\" + "CleaningParameters.txt", "MatchingThreshold: " + nUDMatchingThreshold.Value);
            LoadAfterCleaning();

        }

        bool LoadAGeneFilesToDataGridView(string fileName, DataGridView dataGridView)
        {
            if (File.Exists(@fileName))
            {
                string[] geneStrs = File.ReadAllLines(@fileName);
                DataTable geneTable = new DataTable();
                geneTable.Columns.Add("No.");
                geneTable.Columns.Add("Bit-strings");
                int i = 1;
                foreach (var virus in geneStrs)
                {
                    geneTable.Rows.Add((i++).ToString(), virus);
                }
                this.Invoke((MethodInvoker)delegate
                {
                    dataGridView.DataSource = geneTable;
                });
                return true;
            }
            else
                return false;
        }

        void LoadAfterClustering() 
        {
            string message="Loading is completed.";
            if (!LoadAGeneFilesToDataGridView(@txtMainDirectory.Text+"\\"+"Clustering\\Virus.data", dGVClusteredVirusGeneSet))
            {
                message += " No found clustering virus gene file.";
            }
            if (!LoadAGeneFilesToDataGridView(@txtMainDirectory.Text+"\\"+"Clustering\\Benign.data", dGVClusteredBenignGeneSet))
            {
                message += " No found clustering benign gene file.";
            }
            this.Invoke((MethodInvoker)delegate
            {
                lbClusteringResultMessage.Text = message;
            });
        }
        void LoadAfterCleaning() 
        {
            string message = "Loading is completed.";
            if (!LoadAGeneFilesToDataGridView(@txtMainDirectory.Text + "\\" + "Cleaning\\Virus.data", dGVCleaningVirusGeneSet))
            {
                message += " No found cleaning virus gene file.";
            }
            if (!LoadAGeneFilesToDataGridView(@txtMainDirectory.Text + "\\" + "Cleaning\\Benign.data", dGVCleaningBenignGeneSet))
            {
                message += " No found cleaning benign gene file.";
            }
            this.Invoke((MethodInvoker)delegate
            {
                lbCleaningResultMessage.Text = message;
            });
        }
        void LoadAfterNSA() 
        {
            string message = "Loading is completed.";
            if (!LoadAGeneFilesToDataGridView(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Virus.data", dGVVirusGeneSet_Detector))
            {
                message += " No found virus sample file.";
            }
            if (!LoadAGeneFilesToDataGridView(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Detectors.data", dGVDetector_NSA))
            {
                message += " No found first detector file.";
            }
            this.Invoke((MethodInvoker)delegate
            {
                lbFirstDetectorResult.Text = message;
            });
        }
        void LoadAfteraiNet() 
        {
            string message = "Loading is completed.";
            if (!LoadAGeneFilesToDataGridView(@txtMainDirectory.Text + "\\" + "FirstDetectors\\Detectors.data", dGVFirstDetectors_aiNet))
            {
                message += " No found first detector file.";
            }
            if (!LoadAGeneFilesToDataGridView(@txtMainDirectory.Text + "\\" + "aiNet\\Detectors.data", dGVaiNetDetector_aiNet))
            {
                message += " No found final detector file.";
            }
            this.Invoke((MethodInvoker)delegate
            {
                lbaiNetResult.Text = message;
            });

        }

        private void btnViewClassificationInput_Click(object sender, EventArgs e)
        {
            startElapsedTimer2();
            try
            {
                
                dGVClassificationInput.DataSource = null;
                //string source = txtSourceClassfication.Text;
                //string des = txtDestinationClassfication.Text;
                string source = @txtMainDirectory.Text + "\\" + "Classification\\Training\\Model.txt";
                double[][] inputs;
                int[] labels;
                string[] filename;
                string[] inputStr = File.ReadAllLines(@source);
                inputs = new double[inputStr.Length][];
                labels = new int[inputStr.Length];
                filename = new string[inputStr.Length];
                for (int i = 0; i < inputStr.Length; i++)
                {
                    string[] values = inputStr[i].Split(':');
                    filename[i] = values[0];
                    inputs[i] = new double[] { Double.Parse(values[1], CultureInfo.InvariantCulture), Double.Parse(values[2], CultureInfo.InvariantCulture), Double.Parse(values[3], CultureInfo.InvariantCulture) };
                    labels[i] = Int32.Parse(values[4]);
                }

                DataTable classificationInputTable = new DataTable();
                classificationInputTable.Columns.Add("No.");
                classificationInputTable.Columns.Add("File");
                classificationInputTable.Columns.Add("HA");
                classificationInputTable.Columns.Add("RCBA12");
                classificationInputTable.Columns.Add("RCBA24");
                classificationInputTable.Columns.Add("Label");
                for (int i = 0; i < inputs.Length; i++)
                {
                    classificationInputTable.Rows.Add(i + 1, filename[i], inputs[i][0], inputs[i][1], inputs[i][2], labels[i] == -1 ? "Virus(-1)" : "Benign(1)");
                }
                dGVClassificationInput.DataSource = classificationInputTable;
                stopElapsedTimer2();
                MessageBox.Show("Loading Danger Levels of Model completed");
            }
            catch (Exception g)
            {
                stopElapsedTimer2();
                MessageBox.Show(g.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            startElapsedTimer2();
            DisableClassification();
            BackgroundWorker createModelWorker = new BackgroundWorker();
            createModelWorker.DoWork += new DoWorkEventHandler(createModelWorker_DoWork);
            createModelWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(createModelWorker_RunWorkerCompleted);
            createModelWorker.RunWorkerAsync();
        }

        void DisableClassification() 
        {
            //lbDangerLevelAndClassificationStatus.Text = "Performing... Please wait.";
            DisableComputingLD();
            gBClassification.Enabled = false;
        }
        void EnableClassification()
        {
            //lbDangerLevelAndClassificationStatus.Text = "....";
            EnableComputingLD();
            gBClassification.Enabled = true;
        }

        void createModelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopElapsedTimer2();
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Creating File of Danger Level of Model for Training Data completed");
            EnableClassification();
            this.Invoke((MethodInvoker)delegate { btnViewClassificationInput.PerformClick(); });
        }

        void createModelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            createModelFunction();
        }
        void createModelFunction()
        {
                string trainingVirusDir = @txtMainDirectory.Text + "\\" + "Classification\\Training\\VirusFiles";
                string trainingBenignDir = @txtMainDirectory.Text + "\\" + "Classification\\Training\\BenignFiles";
                string trainingVirusFileDes = @txtMainDirectory.Text + "\\" + "Classification\\Training\\Virus.txt";
                string trainingBenignFileDes = @txtMainDirectory.Text + "\\" + "Classification\\Training\\Benign.txt";
                string modelFile = @txtMainDirectory.Text + "\\" + "Classification\\Training\\Model.txt";
                HashSet<BinaryString> detectors = new HashSet<BinaryString>();
                string[] detectorStrs = File.ReadAllLines(@txtMainDirectory.Text + "\\" + "aiNet\\Detectors.data");
                for (int i = 0; i < detectorStrs.Length; i++)
                {
                    bool[] value = new bool[detectorStrs[i].Length];
                    for (int j = 0; j < value.Length; j++)
                    {
                        value[j] = (detectorStrs[i][j] == '1');
                    }
                    detectors.Add(new BinaryString(value));
                }
                List<LD> ldListVirus = new List<LD>();
                List<LD> ldListBenign = new List<LD>();
                DirectoryInfo diVirus = new DirectoryInfo(@trainingVirusDir);
                DirectoryInfo diBenign = new DirectoryInfo(@trainingBenignDir);

                DangerLevelThreadCell dangerLevelCell = new DangerLevelThreadCell();
                dangerLevelCell.ComputingDangerLevels(diVirus.GetFiles().ToList(), detectors, threadCount);
                ldListVirus = dangerLevelCell.DangerLevels;

                dangerLevelCell.ComputingDangerLevels(diBenign.GetFiles().ToList(), detectors, threadCount);
                ldListBenign = dangerLevelCell.DangerLevels;


                File.WriteAllText(@modelFile, "");
                File.WriteAllText(@trainingVirusFileDes, "");
                FileInfo[] fileInfos = diVirus.GetFiles();
                for (int i = 0; i < fileInfos.Length; i++)
                {
                    File.AppendAllText(@trainingVirusFileDes, ldListVirus[i].FileName + ":" + ldListVirus[i].HA.ToString(CultureInfo.InvariantCulture) + ":" + ldListVirus[i].RCBA12.ToString(CultureInfo.InvariantCulture) + ":" + ldListVirus[i].RCBA24.ToString(CultureInfo.InvariantCulture) + ":" + -1 + "\n");
                    File.AppendAllText(@modelFile, ldListVirus[i].FileName + ":" + ldListVirus[i].HA.ToString(CultureInfo.InvariantCulture) + ":" + ldListVirus[i].RCBA12.ToString(CultureInfo.InvariantCulture) + ":" + ldListVirus[i].RCBA24.ToString(CultureInfo.InvariantCulture) + ":" + -1 + "\n");
                }

                File.WriteAllText(@trainingBenignFileDes, "");
                fileInfos = diBenign.GetFiles();
                for (int i = 0; i < fileInfos.Length; i++)
                {
                    File.AppendAllText(@trainingBenignFileDes, ldListBenign[i].FileName + ":" + ldListBenign[i].HA.ToString(CultureInfo.InvariantCulture) + ":" + ldListBenign[i].RCBA12.ToString(CultureInfo.InvariantCulture) + ":" + ldListBenign[i].RCBA24.ToString(CultureInfo.InvariantCulture) + ":" + 1 + "\n");
                    File.AppendAllText(@modelFile, ldListBenign[i].FileName + ":" + ldListBenign[i].HA.ToString(CultureInfo.InvariantCulture) + ":" + ldListBenign[i].RCBA12.ToString(CultureInfo.InvariantCulture) + ":" + ldListBenign[i].RCBA24.ToString(CultureInfo.InvariantCulture) + ":" + 1 + "\n");
                }

        }


        

        void dangerLevelOfTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!isErrorDefaultComputingDL)
                MessageBox.Show("Done one click");
            EnableClassification();
        }

 
  
        private void btnSourceLD_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSourceLD.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnDestinationLD_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDestinationLD.Text = openFileDialog1.FileName;
            }
        }

      

        private void btnDLFile_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = @txtMainDirectory.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtTestFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnDLFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtTestingFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnLoadClusteringResult_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            BackgroundWorker loadClusteringResultWorker = new BackgroundWorker();
            loadClusteringResultWorker.DoWork += new DoWorkEventHandler(loadClusteringResultWorker_DoWork);
            loadClusteringResultWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadClusteringResultWorker_RunWorkerCompleted);
            loadClusteringResultWorker.RunWorkerAsync();
        }

        void loadClusteringResultWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLoadClusteringResult.Enabled = true;
        }

        void loadClusteringResultWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadAfterClustering();
        }

        private void btnLoadCleaningResult_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            BackgroundWorker loadCleaningResultWorker = new BackgroundWorker();
            loadCleaningResultWorker.DoWork += new DoWorkEventHandler(loadCleaningResultWorker_DoWork);
            loadCleaningResultWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadCleaningResultWorker_RunWorkerCompleted);
            loadCleaningResultWorker.RunWorkerAsync();
        }
        void loadCleaningResultWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLoadCleaningResult.Enabled = true;
        }

        void loadCleaningResultWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadAfterCleaning();
        }

        private void btnLoadFirstDetectorsResult_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            BackgroundWorker loadFirstDetectorsWorker = new BackgroundWorker();
            loadFirstDetectorsWorker.DoWork += new DoWorkEventHandler(loadFirstDetectorsWorker_DoWork);
            loadFirstDetectorsWorker.RunWorkerAsync();
            loadFirstDetectorsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadFirstDetectorsWorker_RunWorkerCompleted);

        }
        void loadFirstDetectorsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLoadFirstDetectorsResult.Enabled = true;
        }

        void loadFirstDetectorsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadAfterNSA();
        }

        private void btnLoadaiNetResult_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            BackgroundWorker loadaiNetResultWorker = new BackgroundWorker();
            loadaiNetResultWorker.DoWork += new DoWorkEventHandler(loadaiNetResultWorker_DoWork);
            loadaiNetResultWorker.RunWorkerAsync();
            loadaiNetResultWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadaiNetResultWorker_RunWorkerCompleted);
        }

        void loadaiNetResultWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLoadaiNetResult.Enabled = true;
        }
        void loadaiNetResultWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadAfteraiNet();
        }

        private void txtModelFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRootDirectoryBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtMainDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void elapsedTimer_Tick(object sender, EventArgs e)
        {
            lbTimeElapsed.Text = "Elapsed time: " + (new TimeSpan(0, 0, ++mTime)).ToString(@"dd\.hh\:mm\:ss") + " (Running)";
        }
        private void startElapsedTimer()
        {
            this.Invoke((MethodInvoker)delegate { mTime = 0; elapsedTimer.Start(); lbTimeElapsed.Text = "Elapsed time: " + (new TimeSpan(0, 0, mTime)).ToString(@"dd\.hh\:mm\:ss") + " (Running)"; });
        }
        private void stopElapsedTimer()
        {
            this.Invoke((MethodInvoker)delegate { elapsedTimer.Stop(); lbTimeElapsed.Text = "Elapsed time: " + (new TimeSpan(0, 0, mTime)).ToString(@"dd\.hh\:mm\:ss") + " (Stopped)"; mTime = 0; });
        }

        private void startElapsedTimer2()
        {
            this.Invoke((MethodInvoker)delegate { mTime2 = 0; elapsedTimer2.Start(); lbDangerLevelAndClassificationStatus.Text = "Elapsed time: " + (new TimeSpan(0, 0, mTime2)).ToString(@"dd\.hh\:mm\:ss") + " (Running)"; });
        }
        private void stopElapsedTimer2()
        {
            this.Invoke((MethodInvoker)delegate { elapsedTimer2.Stop(); lbDangerLevelAndClassificationStatus.Text = "Elapsed time: " + (new TimeSpan(0, 0, mTime2)).ToString(@"dd\.hh\:mm\:ss") + " (Stopped)"; mTime2 = 0; });
        }
        private void elapsedtimer2_Tick(object sender, EventArgs e)
        {
            lbDangerLevelAndClassificationStatus.Text = "Elapsed time: " + (new TimeSpan(0, 0, ++mTime2)).ToString(@"dd\.hh\:mm\:ss") + " (Running)";
        }


        private void startElapsedTimer3()
        {
            this.Invoke((MethodInvoker)delegate { mTime3 = 0; elapsedTimer3.Start(); lbTestStatus.Text = "Elapsed time: " + (new TimeSpan(0, 0, mTime3)).ToString(@"dd\.hh\:mm\:ss") + " (Running)"; });
        }
        private void stopElapsedTimer3()
        {
            this.Invoke((MethodInvoker)delegate { elapsedTimer3.Stop(); lbTestStatus.Text = "Elapsed time: " + (new TimeSpan(0, 0, mTime3)).ToString(@"dd\.hh\:mm\:ss") + " (Stopped)"; mTime3 = 0; });
        }
        private void elapsedTimer3_Tick(object sender, EventArgs e)
        {
            lbTestStatus.Text = "Elapsed time: " + (new TimeSpan(0, 0, ++mTime3)).ToString(@"dd\.hh\:mm\:ss") + " (Running)";
        }
 
    }
    public class LD
    {
        string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        double hA = 0;

        public double HA
        {
            get { return hA; }
            set { hA = value; }
        }
        double rCBA12 = 0;

        public double RCBA12
        {
            get { return rCBA12; }
            set { rCBA12 = value; }
        }
        double rCBA24 = 0;

        public double RCBA24
        {
            get { return rCBA24; }
            set { rCBA24 = value; }
        }
    }
    public class Detector_Aff
    {
        BinaryString detector;

        public BinaryString Detector
        {
            get { return detector; }
            set { detector = value; }
        }
        BinaryString sample;

        public BinaryString Sample
        {
            get { return sample; }
            set { sample = value; }
        }
        double dis;

        public double Distance
        {
            get { return dis; }
            set { dis = value; }
        }
    }
}

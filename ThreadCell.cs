using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VirusDetectionSystem
{
    public class ThreadCell
    {
        public ThreadCell()
        {
            _benignSet = new HashSet<BinaryString>();
            _virusSet = new HashSet<BinaryString>();
        }
        HashSet<BinaryString> _benignSet;
        public HashSet<BinaryString> BSet
        {
            get { return _benignSet; }
            set { _benignSet = value; }
        }
        HashSet<BinaryString> _virusSet;
        public HashSet<BinaryString> VirusSet
        {
            get { return _virusSet; }
            set { _virusSet = value; }
        }
        public void ProcessingVirusGenes(BinaryString[] tvStrings, double maxThreshold, int limitCountforDBSCAN)
        {
            //0.15 * 32;
            int length = tvStrings[0].Value.Length;//Length of a gene
            //Perform clustering

            List<DBSCAN.DBSCANElement> elementSet = new List<DBSCAN.DBSCANElement>();
            for (int i = 0; i < tvStrings.Length; i++)
            {
                elementSet.Add(new DBSCAN.DBSCANElement(tvStrings[i]));
            }
            _virusSet.UnionWith(DBSCAN.DBSCANAlg.Excute(elementSet, maxThreshold, limitCountforDBSCAN));
        }
        public void ProcessingBenignGenes(BinaryString[] bStrings, double maxThreshold, int limitCountforDBSCAN)
        {

            int length = bStrings[0].Value.Length;//Length of a gene
            //Perform clustering

            List<DBSCAN.DBSCANElement> elementSet = new List<DBSCAN.DBSCANElement>();
            for (int i = 0; i < bStrings.Length; i++)
            {
                elementSet.Add(new DBSCAN.DBSCANElement(bStrings[i]));
            }
            _benignSet.UnionWith(DBSCAN.DBSCANAlg.Excute(elementSet, maxThreshold, limitCountforDBSCAN));
        }
    }
}

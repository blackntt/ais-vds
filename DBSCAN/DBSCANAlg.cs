using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Reference from: http://www.c-sharpcorner.com/uploadfile/b942f9/implementing-the-dbscan-algorithm-using-C-Sharp/
namespace VirusDetectionSystem.DBSCAN
{
    public class DBSCANAlg
    {
        public static BinaryString[] Excute(List<DBSCANElement> elementSet, double eps, int minElements)
        {
            List<List<DBSCANElement>> clusters = GetClusters(elementSet, eps, minElements);

            foreach (DBSCANElement p in elementSet)
            {
                if (p.ClusterId == DBSCANElement.NOISE) clusters.Add(new List<DBSCANElement>() { p });
            }
            return GetCentroids(clusters);
        }
        static List<List<DBSCANElement>> GetClusters(List<DBSCANElement> elementSet, double eps, int minElements)
        {
            if (elementSet == null) return null;
            List<List<DBSCANElement>> clusters = new List<List<DBSCANElement>>();
            int clusterId = 1;
            for (int i = 0; i < elementSet.Count; i++)
            {
                DBSCANElement p = elementSet[i];
                if (p.ClusterId == DBSCANElement.UNCLASSIFIED)
                {
                    if (ExpandCluster(elementSet, p, clusterId, eps, minElements)) clusterId++;
                }
            }
            // sort out points into their clusters, if any
            int maxClusterId = elementSet.OrderBy(p => p.ClusterId).Last().ClusterId;
            if (maxClusterId < 1) return clusters; // no clusters, so list is empty
            for (int i = 0; i < maxClusterId; i++) clusters.Add(new List<DBSCANElement>());
            foreach (DBSCANElement p in elementSet)
            {
                if (p.ClusterId > 0) clusters[p.ClusterId - 1].Add(p);
            }
            return clusters;
        }
        static List<DBSCANElement> GetRegion(List<DBSCANElement> elementSet, DBSCANElement p, double eps)
        {
            List<DBSCANElement> region = new List<DBSCANElement>();
            for (int i = 0; i < elementSet.Count; i++)
            {
                int dist = DBSCANElement.Distance(p, elementSet[i]);
                if (dist <= eps) region.Add(elementSet[i]);
            }
            return region;
        }
        static bool ExpandCluster(List<DBSCANElement> elementSet, DBSCANElement p, int clusterId, double eps, int minElements)
        {
            List<DBSCANElement> seeds = GetRegion(elementSet, p, eps);
            if (seeds.Count < minElements) // no core point
            {
                p.ClusterId = DBSCANElement.NOISE;
                return false;
            }
            else // all points in seeds are density reachable from point 'p'
            {
                for (int i = 0; i < seeds.Count; i++) seeds[i].ClusterId = clusterId;
                seeds.Remove(p);
                while (seeds.Count > 0)
                {
                    DBSCANElement currentP = seeds[0];
                    List<DBSCANElement> result = GetRegion(elementSet, currentP, eps);
                    if (result.Count >= minElements)
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            DBSCANElement resultP = result[i];
                            if (resultP.ClusterId == DBSCANElement.UNCLASSIFIED || resultP.ClusterId == DBSCANElement.NOISE)
                            {
                                if (resultP.ClusterId == DBSCANElement.UNCLASSIFIED) seeds.Add(resultP);
                                resultP.ClusterId = clusterId;
                            }
                        }
                    }
                    seeds.Remove(currentP);
                }
                return true;
            }
        }
        static BinaryString[] GetCentroids(List<List<DBSCANElement>> clusterDetails)
        {
            BinaryString[] centroids = new BinaryString[clusterDetails.Count];
            for (int i = 0; i < clusterDetails.Count; i++)
            {
                BinaryString centroid = clusterDetails[i][0].Value;
                double cost = double.MaxValue;
                for (int j = 0; j < clusterDetails[i].Count; j++)
                {
                    double tempCost = 0;
                    for (int k = 0; k < clusterDetails[i].Count; k++)
                    {
                        if (j != k)
                        {
                            tempCost += MatchingMachine.GetHammingDis(clusterDetails[i][j].Value, clusterDetails[i][k].Value);
                        }
                    }

                    if (tempCost < cost)
                    {
                        centroid = clusterDetails[i][j].Value;
                        cost = tempCost;
                    }
                }
                centroids[i] = centroid;
            }
            return centroids;
        }
    }
    public class DBSCANElement
    {
        public const int NOISE = -1;
        public const int UNCLASSIFIED = 0;
        public int ClusterId;
        public BinaryString Value;
        public DBSCANElement(BinaryString value)
        {
            this.Value = value;
        }
        public static int Distance(DBSCANElement p1, DBSCANElement p2)
        {
            return MatchingMachine.GetHammingDis(p1.Value, p2.Value);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Algo
{
    class Program
    {
        const int INF = 1000000000;
        const Double EULER = 2.71828182845904523536;
        const Double EPS = 1e-8;

        static int[] populasi;

        static Double Ifunc(int a, int tt)
        { // kota, hari total a terinfeksi
            Double atas = populasi[a];
            Double bawah = 1.0 + (atas - 1.0) * Math.Pow(EULER, -0.25 * tt);
            return atas / bawah;
        }

        static Double Sfunc(int a, Double fac, int tt)
        { // kota awal, tr(a, b), hari total a terinfeksi
            return Ifunc(a, tt) * fac;
        }

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("../../../populasi.txt");
            string[] line = lines[0].Split(' ');

            int n = Int32.Parse(line[0]);
            string awal = line[1];

            populasi = new int[n + 2];
            string[] getNameFromidx = new string[n + 2];
            var nameIndex = new Dictionary<string, int>();
            
            for (int i = 1; i <= n; i++)
            {
                line = lines[i].Split(' ');
                getNameFromidx[i] = line[0];
                populasi[i] = Int32.Parse(line[1]);
                nameIndex[getNameFromidx[i]] = i;
                //Console.WriteLine(populasi[i]);
            }

            lines = System.IO.File.ReadAllLines("../../../sisi.txt");
            int root = nameIndex[awal];
            line = lines[0].Split();
            int m = Int32.Parse(line[0]);
            List<(int, Double)>[] adjList = new List<(int, Double)>[m + 1];

            // read adjancency list
            for (int i = 1; i <= m; i++)
            {
                line = lines[i].Split(' ');
                int u = nameIndex[line[0]];
                int v = nameIndex[line[1]];
                Double w = Double.Parse(line[2], System.Globalization.CultureInfo.InvariantCulture);
                if (adjList[u] == null)
                {
                    adjList[u] = new List<(int, Double)>();
                }
                adjList[u].Add((v, w));
            }

            line = lines[m + 1].Split(' ');
            int TAkhir = Int32.Parse(line[0]);
            int[] tawal = new int[n + 2];
            for (int i = 1; i <= n; i++)
            {
                tawal[i] = INF;
            }
            tawal[root] = 0;

            var prioQueue = new SortedSet<(int, int)>();
            for (int i = 1; i <= n; i++) {
                (int, int) x = (tawal[i], i);
                prioQueue.Add(x);
            }

            while (prioQueue.Count > 0)
            {
                var cur = prioQueue.First().Item2;
                prioQueue.Remove(prioQueue.First());
                if (tawal[cur] == INF) break;

                foreach (var dest in adjList[cur])
                {
                    if (Sfunc(cur, dest.Item2, TAkhir - tawal[cur]) >= 1.0 - EPS)
                    {
                        int low = 0, high = TAkhir - tawal[cur];

                        while (low < high)
                        {
                            int mid = (low + high) / 2;
                            if (Sfunc(cur, dest.Item2, mid) >= 1.0 - EPS)
                            {
                                high = mid;
                            }
                            else
                            {
                                low = mid + 1;
                            }
                        }

                        int new_t = high + tawal[cur];
                        if (new_t < tawal[dest.Item1])
                        {
                            (int, int) temp = (tawal[dest.Item1], dest.Item1);
                            prioQueue.Remove(temp);
                            tawal[dest.Item1] = new_t;
                            temp = (tawal[dest.Item1], dest.Item1);
                            prioQueue.Add(temp);
                        }
                    }
                }
            }

            Console.WriteLine("Kota yang terinfeksi: ");
            for (int i = 1; i <= n; i++)
            {
                if (tawal[i] != INF)
                {
                    Console.WriteLine(getNameFromidx[i]);
                }
            }
        }
    }
}
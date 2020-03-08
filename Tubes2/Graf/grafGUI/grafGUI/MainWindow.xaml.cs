using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace grafGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int INF = 1000000000;
        const Double EULER = 2.71828182845904523536;
        const Double EPS = 1e-8;

        static int[] populasi;
        static Dictionary<string, int> nameIndex;
        static List<(int, Double)>[] adjList;
        static int TAkhir;
        static int[] TAwal;


        static int root;
        static int n;
        static string[] getNameFromidx;
        static List<int> infectedCity;
        static List<(int, int)> edgeList;
        static List<(int, int)> infectedEdge;

        static string file1, file2;

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

        static void input()
        {   // input dari file populasi.txt dan sisi.txt
            // string[] lines = System.IO.File.ReadAllLines("../../../populasi.txt");
            string[] lines = System.IO.File.ReadAllLines(@file1);
            string[] line = lines[0].Split(' ');

            n = Int32.Parse(line[0]);
            string awal = line[1];

            populasi = new int[n + 1];
            getNameFromidx = new string[n + 1];
            nameIndex = new Dictionary<string, int>();

            for (int i = 1; i <= n; i++)
            {
                line = lines[i].Split(' ');
                getNameFromidx[i] = line[0];
                populasi[i] = Int32.Parse(line[1]);
                nameIndex[getNameFromidx[i]] = i;
            }

            // lines = System.IO.File.ReadAllLines("../../../sisi.txt");
            lines = System.IO.File.ReadAllLines(@file2);
            root = nameIndex[awal];
            line = lines[0].Split();
            int m = Int32.Parse(line[0]);
            adjList = new List<(int, Double)>[m + 1];
            edgeList = new List<(int, int)>();

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
                edgeList.Add((u, v));
            }
            TAwal = new int[n + 2];
            for (int i = 1; i <= n; i++)
            {
                TAwal[i] = INF;
            }
            TAwal[root] = 0;
        }

        static void BFS(int T)
        {   // parameter T = hari
            TAkhir = T;
            var prioQueue = new SortedSet<(int, int)>();
            for (int i = 1; i <= n; i++)
            {
                (int, int) x = (TAwal[i], i);
                prioQueue.Add(x);
            }

            while (prioQueue.Count > 0)
            {
                var cur = prioQueue.First().Item2;
                prioQueue.Remove(prioQueue.First());
                if (TAwal[cur] == INF) break;

                foreach (var dest in adjList[cur])
                {
                    if (Sfunc(cur, dest.Item2, TAkhir - TAwal[cur]) >= 1.0 - EPS)
                    {
                        int low = 0, high = TAkhir - TAwal[cur];

                        while (low < high)
                        {   // binary search untuk mencari durasi yang dibutuhkan untuk menginfeksi kota lain
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

                        int new_t = high + TAwal[cur];
                        if (new_t < TAwal[dest.Item1])
                        {
                            (int, int) temp = (TAwal[dest.Item1], dest.Item1);
                            prioQueue.Remove(temp);
                            TAwal[dest.Item1] = new_t;
                            temp = (TAwal[dest.Item1], dest.Item1);
                            prioQueue.Add(temp);
                        }
                    }
                }
            }

            infectedCity = new List<int>();
            for (int i = 1; i <= n; i++)
            {   // mencatat semua kota yang berwarna merah (terinfeksi)
                if (TAwal[i] != INF)
                {
                    infectedCity.Add(i);
                }
            }

            infectedEdge = new List<(int, int)>();
            foreach (int node in infectedCity)
            {
                foreach (var dest in adjList[node])
                {   // mencatat semua edge yang berwarna merah (S(A, B) >= 1)
                    if (Sfunc(node, dest.Item2, TAkhir - TAwal[node]) >= 1.0 - EPS)
                    {
                        infectedEdge.Add((node, dest.Item1));
                    }
                }
            }
        }

        public static int getCityCount()
        {
            return n;
        }

        public static string[] allCityName()
        {
            return getNameFromidx;
        }

        public static List<int> getInfectedCity()
        {
            return infectedCity;
        }

        public static List<(int, int)> getEdgeList()
        {
            return edgeList;
        }

        public static List<(int, int)> getInfectedEdge()
        {
            return infectedEdge;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                file1 = dlg.FileName;
                ChoosenFile.Text = file1;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                file2 = dlg.FileName;
                ChoosenFile2.Text = file2;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string temp = "";
            int query = Int32.Parse(Query.Text);
            input();
            BFS(query);
            temp = temp + "Kota yang terinfeksi: \n";
            foreach (int x in infectedCity)
            {
                temp = temp + getNameFromidx[x] + "\n";
            }

            Hasil.Text = temp;
        }
    }

    
}

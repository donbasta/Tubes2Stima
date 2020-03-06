/*
FORMAT INPUT:
BANYAK_KOTA(N)  KOTA_AWAL_INFEKSI

KOTA_1  POPULASI_1
...
KOTA_N  POPULASI_N

BANYAK_EDGE

KOTA_AWAL  KOTA_AKHIR  TR(AWAL, AKHIR)
...


T_AKHIR

*/

#include <bits/stdc++.h>


#define fi first
#define se second
#define pb push_back
#define mp make_pair
#define MOD 1000000007
#define pii pair<int,int>
#define pli pair<long long,int>
#define pil pair<int,long long>
#define ll long long
#define el '\n'

using namespace std;

const int N = 1e5 + 10;
const int INF = 1e9;
const double EULER = 2.71828182845904523536; 
const double EPS = 1e-8;

int n, m;
vector <pair<int, double>> adjList[N];
int populasi[N];
map <string, int> nameIndex;
string awal;
string getNameFromIdx[N];
int root;

int tawal[N];
int Takhir;
set <pair<int, int>> setdah; // tawal, node

double Ifunc(int a, int tt){ // kota, hari total a terinfeksi
    double atas = double(populasi[a]);
    double bawah = 1.0 + (atas - 1.0) * pow(EULER, -0.25 * tt);
    return atas / bawah;
}

double Sfunc(int a, double fac, int tt){ // kota awal, tr(a, b), hari total a terinfeksi
    return Ifunc(a, tt) * fac;
}

int main () {
    ios_base::sync_with_stdio(false);
    cin.tie(0);
    cout.tie(0);

    cin >> n >> awal;
    for (int i=1;i<=n;i++){
        cin >> getNameFromIdx[i] >> populasi[i];
        nameIndex[getNameFromIdx[i]] = i;
    }
    root = nameIndex[awal];

    cin >> m;
    for (int i=1;i<=m;i++){
        string sa, sb;
        double w;
        cin >> sa >> sb >> w;
        int a = nameIndex[sa];
        int b = nameIndex[sb];

        adjList[a].pb(mp(b, w));
    }

    cin >> Takhir;
    fill(tawal, tawal + n + 2, INF);
    tawal[root] = 0;
    for (int i=1;i<=n;i++){
        setdah.insert(mp(tawal[i], i));
    }

    while (!setdah.empty()){
        auto cur = *(setdah.begin());
        setdah.erase(setdah.begin());

        for (auto dest : adjList[cur.se]){
            if (Sfunc(cur.se, dest.se, Takhir - tawal[cur.se]) >= 1.0 - EPS){
                int low = 0, high = Takhir - tawal[cur.se];

                while (low < high){
                    int mid = (low + high) / 2;
                    if (Sfunc(cur.se, dest.se, mid) >= 1.0 - EPS){
                        high = mid;
                    } else{
                        low = mid + 1;
                    }
                }

                int new_t = high + tawal[cur.se]; 
                if (new_t < tawal[dest.fi]){
                    setdah.erase(mp(tawal[dest.fi], dest.fi));
                    tawal[dest.fi] = new_t;
                    setdah.insert(mp(tawal[dest.fi], dest.fi));
                }
            }
        }
    }
    cout << "Kota yang terinfeksi:" << el; 
    for (int i=1;i<=n;i++){
        if (tawal[i] != INF){
            cout << getNameFromIdx[i] << el;
        }
    }

    return 0;
}
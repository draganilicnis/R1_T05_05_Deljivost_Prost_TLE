// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka2/prost_broj
// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/prost_broj
// https://arena.petlja.org/sr-Latn-RS/competition/r1-t05-deljivost-prosti-tle-001-2024#tab_132331
// https://www.petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/prost_broj
// https://petlja.org/sr-Latn-RS/kurs/14606/23/2755
// https://onlinegdb.com/JeTNwk0_R
// https://onlinegdb.com/Enxnz_kWT

using System;
// using System.Diagnostics;

class R1_T05_05_Deljivost_Prost
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        // n = 1000 * 1000 * 1000 + 7;
        Console.WriteLine(Prost_04(n) ? "DA" : "NE");

        //Stopwatch t = new Stopwatch();
        //t.Start(); Console.Write(Prost_00(n) ? "DA" : "NE"); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        //t.Start(); Console.Write(Prost_01(n) ? "DA" : "NE"); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        //t.Start(); Console.Write(Prost_02(n) ? "DA" : "NE"); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        //t.Start(); Console.Write(Prost_03(n) ? "DA" : "NE"); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        //t.Start(); Console.Write(Prost_04(n) ? "DA" : "NE"); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
    }

    // Slozenost: O(N): Linerna pretraga: Naivni algoritam:
    // Ispituje sve delioce od 2 do n
    static bool Prost_00(int n)
    {
        bool prost = false;
        if (n == 1) prost = false;     // broj 1 nije prost
        else
        {
            prost = true;
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                {
                    prost = false; // break;
                }    
                    
        }
        return prost;
    }

    // Slozenost: O(N): Linerna pretraga: Naivni algoritam:
    // Ispituje sve delioce od 2 do n, ali cim naidje na prvi kojim je deljiv prekida izvrsavanje petlje
    static bool Prost_01(int n)
    {
        if (n == 1) return false;     // broj 1 nije prost
        for (int i = 2; i < n; i++)
            if (n % i == 0)
                return false;
        return true;
    }

    // Slozenost: O(Sqrt(N)): Odsecanje u pretrazi:
    // Ispituje sve delioce od 2 do Sqrt(n)
    static bool Prost_02(int n)
    {
        if (n == 1) return false;
        for (int i = 2; i * i <= n; i++)
            if (n % i == 0)
                return false;
        return true;
    }

    // Slozenost: O(Sqrt(N)): Odsecanje u pretrazi: Ispituje sve delioce od 2 do Sqrt(n)
    // Provera samo neparnih brojeva, duplo brze, sto je srazmerno znatno manja usteda
    static bool Prost_03(int n)
    {
        if (n == 1) return false;     // broj 1 nije prost
        if (n == 2) return true;      // broj 2 jeste prost
        if (n % 2 == 0) return false; // ostali parni brojevi nisu prosti
        // proveravamo neparne delioce od 3 do korena iz n
        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0)
                return false;
        // nismo nasli delioca - broj jeste prost
        return true;
    }

    // Slozenost: O(Sqrt(N)): Odsecanje u pretrazi: Ispituje sve delioce od 2 do Sqrt(n)
    // Provera samo brojeva oblika 6k-1 i 6k+1 : 5, 7, 11, 13, 17, 19, 23, 25, 29, 31, 35, 37...(ne proverava 9, 15, 21, 27, 33, jer su deljivi sa 3)
    // Provera sa jednog na svaka tri neparna broja, brze, sto je srazmerno znatno manja usteda
    static bool Prost_04(int n)
    {
        if (n == 1 ||
            (n % 2 == 0 && n != 2) ||
            (n % 3 == 0 && n != 3))
            return false;
        for (int k = 1; (6 * k - 1) * (6 * k - 1) <= n; k++)
            if (n % (6 * k + 1) == 0 || n % (6 * k - 1) == 0)
                return false;
        return true;
    }
}

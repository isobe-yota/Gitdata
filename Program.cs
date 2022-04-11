using System;
using System.Collections.Generic;

public class Program
{
    static Dictionary<string, List<string>> mDictionary = new Dictionary<string, List<string>>();

    public List<string> this[string key]
    {
        get { return mDictionary[key]; }
        set { mDictionary[key] = value; }
    }


    public Dictionary<string, List<string>>.KeyCollection Keys
    {
        get { return mDictionary.Keys; }
    }


    public Dictionary<string, List<string>>.ValueCollection Values
    {
        get { return mDictionary.Values; }
    }


    public int Count
    {
        get { return mDictionary.Count; }
    }


    public void Add(string key, string value)
    {
        if (!mDictionary.ContainsKey(key))
        {
            mDictionary.Add(key, new List<string>());
        }
        mDictionary[key].Add(value);
    }


    public void Add(string key, params string[] values)
    {
        foreach (var n in values)
        {
            Add(key, n);
        }
    }


    public void Add(string key, IEnumerable<string> values)
    {
        foreach (var n in values)
        {
            Add(key, n);
        }
    }

    public bool Remove(string key, string value)
    {
        return mDictionary[key].Remove(value);
    }

    public bool Remove(string key)
    {
        return mDictionary.Remove(key);
    }

    public void Clear()
    {
        mDictionary.Clear();
    }

    public bool Contains(string key, string value)
    {
        return mDictionary[key].Contains(value);
    }

    public void Search(string key)
    {
        Console.WriteLine("検索ワード :" + key);

        if (mDictionary.ContainsKey(key))
        {
            foreach (var n in mDictionary[key])
            {
                Console.WriteLine(n);
            }
        }
        else
        {

        }
    }

    static void Main()
    {
        var sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        var m = new Program();
        m.Add("哺乳類", "人");
        m.Add("哺乳類", "クジラ");
        m.Add("哺乳類", "カンガルー");
        m.Add("魚類", "イワシ");

        for (int i = 0; i < 100000; i++)
        {
            int num = i;
            m.Add(num.ToString(), num.ToString() + "value");
        }
        //哺乳類検索したとき
        m.Search("哺乳類");
        m.Search("2");
        // //辞書全データ
        // foreach (var pair in mDictionary)
        // {
        //     foreach (var n in pair.Value)
        //     {
        //        Console.WriteLine(pair.Key + ": " + n);
        //     }
        // }

        sw.Stop();
        Console.WriteLine("■処理にかかった時間");
        TimeSpan ts = sw.Elapsed;
        Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");
        Console.WriteLine("入力して");
        string words = Console.ReadLine();
        Console.WriteLine("今入力した文字: {0}");
        m.Search(words);
        Console.ReadLine();

        Console.WriteLine("hello");
    }
}

using System.Text;

// 1400. Construct K Palindrome Strings
bool CanConstruct(string s, int k)
{
    if (k > s.Length)
        return false;
    int[] freq = new int[26];
    foreach (char c in s)
        freq[c - 'a']++;
    int oddCount = 0;
    foreach (int count in freq)
        if (count % 2 != 0)
            oddCount++;
    return oddCount <= k;
}

//68. Text Justification - решено
IList<string> FullJustify(string[] words, int maxWidth)
{
    IList<string> result = new List<string>();
    List<string> lineWords = new List<string>();
    int lineLength = 0;
    foreach (var word in words)
    {
        if (lineLength + word.Length + lineWords.Count > maxWidth)
        {
            result.Add(JustifyLine(lineWords, lineLength, maxWidth));
            lineWords.Clear();
            lineLength = 0;
        }
        lineWords.Add(word);
        lineLength += word.Length;
    }
    if (lineWords.Count > 0)
    {
        string lastLine = string.Join(" ", lineWords).PadRight(maxWidth);
        result.Add(lastLine);
    }
    return result;
}
string JustifyLine(List<string> words, int lineLength, int maxWidth)
{
    if (words.Count == 1)
        return words[0].PadRight(maxWidth);
    int totalSpaces = maxWidth - lineLength;
    int spacesBetween = totalSpaces / (words.Count - 1);
    int extraSpaces = totalSpaces % (words.Count - 1);
    StringBuilder justifiedLine = new StringBuilder();
    for (int i = 0; i < words.Count; i++)
    {
        justifiedLine.Append(words[i]);
        if (i < words.Count - 1)
            justifiedLine.Append(' ', spacesBetween + (i < extraSpaces ? 1 : 0));
    }
    return justifiedLine.ToString();
}


string ReplaceDigits(string s)
{
    char ch = ' ';
    string result = "";
    foreach (var item in s)
    {
        if (char.IsDigit(item))
            result += (char)(ch + (item - '0'));
        else
        {
            ch = item;
            result += item;
        }
    }
    return result;
}

string LongestCommonPrefix1(string[] strs)
{
    string prefix = "";
    int index = 0;
    foreach (var s in strs)
    {
        prefix += s[index];
        for (int i = 0; i < strs.Length; i++)
            if (!strs[i].StartsWith(prefix))
                return prefix = prefix[..^1];
        index++;
    }
    return "";
}
// 14. Longest Common Prefix - решено
string LongestCommonPrefix2(string[] strs)
{
    if (strs == null || strs.Length == 0)
        return "";
    string prefix = strs[0];
    foreach (string s in strs)
        while (!s.StartsWith(prefix))
        {
            prefix = prefix[..^1];
            if (string.IsNullOrEmpty(prefix))
                return "";
        }
    return prefix;
}


// 1. Two Sum - решено
int[] TwoSum(int[] nums, int target)
{
    for (int i = 0; i < nums.Length; i++)
        for (int j = i + 1; j < nums.Length; j++)
            if (nums[i] + nums[j] == target)
                return [i, j];
    return [];
}

// 9. Palindrome Number - решено
bool IsPalindrome(int x)
{
    var palindrome = x.ToString();
    char[] reversed = palindrome.ToCharArray();
    Array.Reverse(reversed);
    return new string(reversed) == palindrome;
}

int MySqrt(int x)
{
    return (int)Math.Sqrt(x);
}

// 27. Remove Element - решено
int RemoveElement(int[] nums, int val)
{
    int resultLength = 0;
    foreach (int num in nums)
        if (num != val)
            nums[resultLength++] = num;
    return resultLength;
}

// 26. Remove Duplicates from Sorted Array - решено
int RemoveDuplicates(int[] nums)
{
    int count = 0;
    foreach (var num in nums)
        if (count == 0 || num != nums[count - 1])
            nums[count++] = num;
    return count;
}

// 58. Length of Last Word - решено
int LengthOfLastWord(string s)
{
    string[] words = s.Trim().Split(' ');
    return words[^1].Length;
}

// 916. Word Subsets - не решено
IList<string> FindUniversalWords(string[] words1, string[] words2)
{
    IList<string> result = new List<string>();
    int[] maxFreq = new int[26];
    foreach (string word in words2)
    {
        int[] freq = CalculateFrequency(word);
        for (int i = 0; i < 26; i++)
            maxFreq[i] = Math.Max(maxFreq[i], freq[i]);
    }
    foreach (string word in words1)
    {
        int[] freq = CalculateFrequency(word);
        if (IsUniversal(freq, maxFreq))
            result.Add(word);
    }
    return result;
}

int[] CalculateFrequency(string word)
{
    int[] freq = new int[26];
    foreach (char c in word)
        freq[c - 'a']++;
    return freq;
}

bool IsUniversal(int[] freq, int[] maxFreq)
{
    for (int i = 0; i < 26; i++)
        if (freq[i] < maxFreq[i])
            return false;
    return true;
}


bool IsPowerOfFour(int n)
{
    return n == Math.Pow(4, n);
}

// 747. Largest Number At Least Twice of Others
int DominantIndex(int[] nums)
{
    int highestNum = int.MinValue;
    int index = 0;
    for (int i = 0; i < nums.Length; i++)
        if (nums[i] > highestNum) 
        { 
            highestNum = nums[i];
            index = i;
        }
    foreach (var item in nums)
        if (item != highestNum && highestNum < item * 2) return -1;
    return index;
}

// 28. Find the Index of the First Occurrence in a String - решено
int StrStr(string haystack, string needle)
{
    for (int i = 0; i < haystack.Length; i++)
    {
        string temp = "";
        if(i + needle.Length <= haystack.Length)
            for (int j = i; j < needle.Length + i; j++)
                temp += haystack[j];
        if(needle == temp)
            return i;
    }
    return -1;
}

// 3340. Check Balanced String - решено
bool isBalanced(string num)
{
    int even = 0, odd = 0;
    for (int i = 1; i <= num.Length; i++)
    {
        int currentDigit = num[i - 1] - '0';
        if (i % 2 == 0)
            even += currentDigit;
        else
            odd += currentDigit;
    }
    return even == odd;
}

// 2185. Counting Words With a Given Prefix - решено
int PrefixCount(string[] words, string pref)
{
    int prefCount = 0;
    foreach (var word in words)
        if (word.StartsWith(pref))
            prefCount++;
    return prefCount;
}

// 66. Plus One - не решено
int[] PlusOne(int[] digits)
{
    string s = "";
    foreach (var item in digits)
        s += item;
    int number = int.Parse(s);
    s = $"{number += 1}";
    for (int i = 0; i < digits.Length; i++)
        digits[i] = s[i] - '0';
    return digits;
}

// 66. Plus One - решено
int[] PlusOne1(int[] digits)
{
    for (int i = digits.Length - 1; i >= 0; i--)
    {
        if (digits[i] < 9)
        {
            digits[i]++;
            return digits;
        }
        digits[i] = 0;
    }
    int[] result = new int[digits.Length + 1];
    result[0] = 1;
    return result;
}

// 645. Set Mismatch - не решено
int[] FindErrorNums(int[] nums)
{
    for (int i = 0; i < nums.Length; i++)
        for (int j = 0; j < nums.Length; j++)
        {
            if (j == i) continue;
            if (nums[j] == nums[i])
                return [j, nums[j] + 1];
        }
    return [];
}

// 1979. Find Greatest Common Divisor of Array - не решено
int FindGCD(int[] nums)
{
    int lowestNum = int.MaxValue, highestNum = int.MinValue;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] < lowestNum) lowestNum = nums[i];
        if (nums[i] > highestNum) highestNum = nums[i];
    }
    int gcd = 0;
    while (highestNum != 0)
    {
        int temp = highestNum;
        highestNum = lowestNum % highestNum;
        gcd = temp;
    }
    return gcd;
}

// 1784. Check if Binary String Has at Most One Segment of Ones - решено
bool CheckOnesSegment(string s)
{
    return !s.Contains("01");
}

// 34. Find First and Last Position of Element in Sorted Array - решено
int[] SearchRange(int[] nums, int target)
{
    int startRange = -1, endRange = -1;
    for (int i = 0; i < nums.Length; i++)
        if (nums[i] == target)
        {
            if (startRange == -1)
                startRange = i;
            endRange = i;
        }
    return [startRange, endRange];
}

int SearchInsert(int[] nums, int target)
{
    int index = 0;    
    return index;
}

// 506. Relative Ranks - решено
string[] FindRelativeRanks(int[] score)
{
    int n = score.Length;
    int[] idx = Enumerable.Range(0, n).ToArray();
    Array.Sort(idx, (a, b) => score[b].CompareTo(score[a]));
    string[] result = new string[n];
    string[] top3 = { "Gold Medal", "Silver Medal", "Bronze Medal" };
    for (int i = 0; i < n; i++)
        result[idx[i]] = i < 3 ? top3[i] : (i + 1).ToString();
    return result;
}

// 2710. Remove Trailing Zeros From a String - решено
string RemoveTrailingZeros(string num)
{
    return num.TrimEnd('0');
}

// 2325. Decode the Message - решено
string DecodeMessage(string key, string message)
{
    char[] decoder = new char[128];
    decoder[' '] = ' ';
    int decoderIndex = 0;
    foreach (char currentChar in key)
        if (decoder[currentChar] == 0)
            decoder[currentChar] = (char)('a' + decoderIndex++);
    char[] decodedMessage = message.Select(c => decoder[c]).ToArray();
    return new string(decodedMessage);
}

// 2869. Minimum Operations to Collect Elements - решено
int MinOperations(IList<int> nums, int k)
{
    bool[] isNumberAdded = new bool[k];
    int n = nums.Count, count = 0;
    for (int i = n - 1; i >= 0; i--)
    {
        int currentValue = nums[i];
        if (currentValue > k || isNumberAdded[currentValue - 1]) continue;
        isNumberAdded[currentValue - 1] = true;
        count++;
        if (count == k) return n - i;
    }
    return -1;
}

// 706. Design HashMap - не решено
public class MyHashMap
{
    private int[] hashMap;
    public MyHashMap() => hashMap = new int[1000001];
    public void Put(int key, int value) => hashMap[key] = value;
    public int Get(int key) => hashMap[key];
    public void Remove(int key) => hashMap[key] = -1;
}
﻿Console.WriteLine(LengthOfLastWord("Hello World"));
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

// 27. Remove Element - решено
int RemoveElement(int[] nums, int val)
{
    int resultLength = 0;
    foreach (int num in nums)
        if (num != val)
            nums[resultLength++] = num;
    return resultLength;
}

// 26. Remove Duplicates from Sorted Array
int RemoveDuplicates(int[] nums)
{
    int count = 0;
    foreach (var num in nums)
        if (count == 0 || num != nums[count - 1])
            nums[count++] = num;
    return count;
}

//58. Length of Last Word
int LengthOfLastWord(string s)
{
    string[] words = s.Trim().Split(' ');
    return words[^1].Length;
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

// 2185. Counting Words With a Given Prefix
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

// Check binaries - решено
bool CheckOnesSegment(string s)
{
    return s.Contains("11");
}

int[] SearchRange(int[] nums, int target)
{
    int[] range = new int[2];
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == target)
            range[0] += i;
    }
    return range;
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
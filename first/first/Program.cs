// See https://aka.ms/new-console-template for more information
int[] nums = { 10, 20, 30, 40, 20, 30};

Dictionary<int, int> dict = new Dictionary<int, int>();



var temp = new HashSet<Int32>();

for (int i = 0; i < nums.Length; i++)
{
    if (temp.Contains(nums[i]))
    {
        Console.WriteLine(nums[i] + " is a duplicate");
    }
    else
    {
        temp.Add(nums[i]);
    }
}
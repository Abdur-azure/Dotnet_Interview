using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Interview
{
    public class Code
    {
        string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        bool AreAnagrams(string str1, string str2)
        {
            char[] charArray1 = str1.ToCharArray();
            char[] charArray2 = str2.ToCharArray();
            Array.Sort(charArray1);
            Array.Sort(charArray2);
            return new string(charArray1) == new string(charArray2);
        }

        IEnumerable<int> FindDuplicates(int[] array)
        {
            var duplicates = array.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key);
            return duplicates;
        }

        public class Stack<T>
        {
            private List<T> items = new List<T>();

            public void Push(T item)
            {
                items.Add(item);
            }

            public T Pop()
            {
                if (items.Count == 0)
                    throw new InvalidOperationException("Stack is empty");
                T result = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);
                return result;
            }

            public bool IsEmpty => items.Count == 0;
        }

        int FindMissingNumber(int[] array)
        {
            int n = array.Length + 1;
            int expectedSum = n * (n + 1) / 2;
            int actualSum = array.Sum();
            return expectedSum - actualSum;
        }

        int BinarySearch(int[] array, int target)
        {
            int left = 0, right = array.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] == target)
                    return mid;
                else if (array[mid] < target)
                    left = mid + 1;
                else

                    right = mid - 1;
            }
            return -1; // Not found
        }

        bool IsPalindrome(string str)
        {
            str = str.ToLower();
            int left = 0, right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        char FirstNonRepeatingCharacter(string str)
        {
            var charCount = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }
            foreach (char c in str)
            {
                if (charCount[c] == 1)
                    return c;
            }
            return '\0'; // No non-repeating character found
        }

        public class QueueUsingStacks<T>
        {
            private Stack<T> stack1 = new Stack<T>();
            private Stack<T> stack2 = new Stack<T>();

            public void Enqueue(T item)
            {
                while (stack1.Count > 0)
                    stack2.Push(stack1.Pop());
                stack1.Push(item);
                while (stack2.Count > 0)
                    stack1.Push(stack2.Pop());
            }

            public T Dequeue()
            {
                if (stack1.Count == 0)
                    throw new InvalidOperationException("Queue is empty");
                return stack1.Pop();
            }

            public bool IsEmpty => stack1.Count == 0;
        }

        public class ListNode
        {
            public int Value;
            public ListNode Next;
            public ListNode(int value) { Value = value; }
        }

        ListNode ReverseLinkedList(ListNode head)
        {
            ListNode prev = null, current = head, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        bool AreParenthesesBalanced(string expression)
        {
            var stack = new Stack<char>();
            foreach (char c in expression)
            {
                if (c == '(' || c == '[' || c == '{')
                    stack.Push(c);
                else if (c == ')' && (stack.Count == 0 || stack.Pop() != '('))
                    return false;
                else if (c == ']' && (stack.Count == 0 || stack.Pop() != '['))
                    return false;
                else if (c == '}' && (stack.Count == 0 || stack.Pop() != '{'))
                    return false;
            }
            return stack.Count == 0;
        }

        ListNode FindIntersection(ListNode head1, ListNode head2)
        {
            HashSet<ListNode> set = new HashSet<ListNode>();
            while (head1 != null)
            {
                set.Add(head1);
                head1 = head1.Next;
            }
            while (head2 != null)
            {
                if (set.Contains(head2))
                    return head2;
                head2 = head2.Next;
            }
            return null; // No intersection found
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
            public bool IsEndOfWord;
        }

        public class Trie
        {
            private TrieNode root = new TrieNode();

            public void Insert(string word)
            {
                TrieNode node = root;
                foreach (char c in word)
                {
                    if (!node.Children.ContainsKey(c))
                        node.Children[c] = new TrieNode();
                    node = node.Children[c];
                }
                node.IsEndOfWord = true;
            }

            public bool Search(string word)
            {
                TrieNode node = SearchNode(word);
                return node != null && node.IsEndOfWord;
            }

            private TrieNode SearchNode(string word)
            {
                TrieNode node = root;
                foreach (char c in word)
                {
                    if (node.Children.ContainsKey(c))
                        node = node.Children[c];
                    else
                        return null; // Prefix not found
                }
                return node;
            }

            public bool StartsWith(string prefix)
            {
                return SearchNode(prefix) != null;
            }
        }

        void RotateArray(int[] nums, int k)
        {
            k = k % nums.Length;
            ReverseArray(nums, 0, nums.Length - 1);
            ReverseArray(nums, 0, k - 1);
            ReverseArray(nums, k, nums.Length - 1);
        }

        void ReverseArray(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        void MergeSortedArrays(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                    nums1[k--] = nums1[i--];
                else
                    nums1[k--] = nums2[j--];
            }
            while (j >= 0)
                nums1[k--] = nums2[j--];
        }

        int LengthOfLongestSubstring(string s)
        {
            int n = s.Length, maxLength = 0;
            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();
            for (int i = 0, j = 0; j < n; j++)
            {
                if (charIndexMap.ContainsKey(s[j]))
                    i = Math.Max(charIndexMap[s[j]] + 1, i);
                maxLength = Math.Max(maxLength, j - i + 1);
                charIndexMap[s[j]] = j;
            }
            return maxLength;
        }

        public sealed class Singleton
        {
            private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());

            public static Singleton Instance => lazy.Value;

            private Singleton() { }
        }

        int CountSetBits(int num)
        {
            int count = 0;
            while (num > 0)
            {
                count += num & 1;
                num >>= 1;
            }
            return count;
        }

        int FindPeakElement(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > nums[mid + 1])
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }

        double Power(double x, int n)
        {
            if (n == 0) return 1;
            if (n < 0)
            {
                x = 1 / x;
                n = -n;
            }
            double result = 1;
            while (n > 0)
            {
                if (n % 2 == 1)
                    result *= x;
                x *= x;
                n /= 2;
            }
            return result;
        }

        public class LRUCache
        {
            private readonly int capacity;
            private readonly Dictionary<int, int> cache;
            private readonly LinkedList<int> recentlyUsed;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                cache = new Dictionary<int, int>(capacity);
                recentlyUsed = new LinkedList<int>();
            }

            public int Get(int key)
            {
                if (cache.TryGetValue(key, out int value))
                {
                    recentlyUsed.Remove(key);
                    recentlyUsed.AddLast(key);
                    return value;
                }
                return -1; // Not found
            }

            public void Put(int key, int value)
            {
                if (cache.Count >= capacity)
                {
                    int leastRecentlyUsed = recentlyUsed.First.Value;
                    recentlyUsed.RemoveFirst();
                    cache.Remove(leastRecentlyUsed);
                }
                cache[key] = value;
                recentlyUsed.Remove(key);
                recentlyUsed.AddLast(key);
            }
        }
    }
}

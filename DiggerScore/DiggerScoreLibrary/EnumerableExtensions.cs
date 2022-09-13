using System.Text;

namespace Validation
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<object> UpdateById(this IEnumerable<object> _)
        {
            int i = 1;
            Type? type = _.GetType().GetGenericArguments()[0];

            foreach (var item in _)
            {
                type.GetProperty("Id")!.SetValue(item, i++);
            }

            return _;
        }

        public static void ToConsoleTable(this IEnumerable<object> _, Dictionary<string, string> dictionary)
        {
            #region Table creating

            Type? type = _.GetType().GetGenericArguments()[0];

            int n = _.Count()+1;
            int m = dictionary.Count;
            string[,]? listToArray = new string[n, m];

            int i = 1;
            int j = 0;

            foreach (var item in _)
            {
                j = 0;

                foreach (var value in dictionary)
                {
                    string? stringProperty = type.GetProperty(value.Value.ToString()!)!.GetValue(item)!.ToString();
                    if (value.Value.Equals("password", StringComparison.OrdinalIgnoreCase))
                        listToArray[i, j] = stringProperty!.ToHiddenString()!;
                    else listToArray[i, j]=stringProperty!;
                    
                    j++;
                }

                i++;
            }

            i =0;
            j=0;

            foreach (var value in dictionary)
            {
                listToArray[i, j]= value.Key.ToString()!;
                j++;
            }

            #endregion

            #region Table formating

            int[] maxLengthArray = new int[m];

            for (j = 0; j < m; j++)
            {
                int maxLength = listToArray[0, j].Length;
                for (i = 1; i < n; i++)
                {
                    if (listToArray[i, j].Length > maxLength) maxLength = listToArray[i, j].Length;
                }
                maxLengthArray[j]= maxLength+1;
            }

            StringBuilder[]? stringBuilders = new StringBuilder[n];

            char horizontallLine = (char)9472;
            char space = (char)32;

            for (i=0; i<n; i++)
            {
                stringBuilders[i] = new();
                for (j = 0; j < m; j++)
                {
                    stringBuilders[i].Append(listToArray[i, j]);

                    for (int k = 0; k<maxLengthArray[j]-listToArray[i, j].Length; k++)
                    {
                        stringBuilders[i].Append(space);
                    }
                }
            }

            #endregion

            #region Table drawning

            for (i=0; i<n; i++)
            {
                Console.WriteLine(stringBuilders[i]);

                for (int c = 0; c<stringBuilders[i].Length; c++) Console.Write(horizontallLine);

                Console.WriteLine();
            }

            #endregion
        }
    }
}
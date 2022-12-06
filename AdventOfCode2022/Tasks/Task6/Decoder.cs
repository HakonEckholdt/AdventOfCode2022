namespace AdventOfCode2022.Tasks.Task6
{
    public static class Decoder
    {
        public static int GetFirstMarkerPosition(string data, int uniqueLetters, out string markerOut)
        {
            markerOut = "";
            for(var i = 0; i < data.Length - uniqueLetters; i++)
            {
                var marker = data.Skip(i).Take(uniqueLetters);
                if (marker.Distinct().Count() == uniqueLetters)
                {
                    markerOut = string.Join(string.Empty, marker);
                    return i + uniqueLetters;
                }
            }
            markerOut = string.Empty;
            return 0;
        }
    }
}

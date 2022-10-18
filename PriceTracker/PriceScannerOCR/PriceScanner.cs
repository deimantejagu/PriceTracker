namespace PriceTracker.PriceScannerOCR
{
    public class PriceScanner
    {
        //private string url = "https://api.mindee.net/v1/products/vrapas/test/v1/predict";
        //private string token = "eb22ad7dad7171577372b9b4c93b1c35";
        //public static string[] files = Directory.GetFiles(@"Images", "*.jpg");

        /*public void Labas()
        {
            IEnumerable<string> image = (IEnumerable<string>)(from files in Enumerable.Range(0, files.Length)
                                                              select files);
            foreach (string image in files)
            {
                Console.WriteLine($"IENUMERABLE: {image}");
            }
        }*/

        /*public void ScanData()
        {
            foreach(string image in files)
            {
                Console.WriteLine(image);
                var filePath = image;

                var file = File.OpenRead(filePath);
                var streamContent = new StreamContent(file);
                var imageContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                var form = new MultipartFormDataContent();
                form.Add(imageContent, "document", Path.GetFileName(filePath));

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);
                var response = httpClient.PostAsync(url, form).Result;
                File.WriteAllText("output.json", response.Content.ReadAsStringAsync().Result);
            }*/

        /*IEnumerable<string> image = (IEnumerable<string>)(from files in Enumerable.Range(0, files.Length)
                                    select files);
        Console.WriteLine(image);

        int location = 0;
        List<string> prices = new List<string>();
        List<string> words = new List<string>();
        string oneWord = "";
        // Change the path with your own:
        string readText = File.ReadAllText("output.json");

        // Collects all "words" into a list
        for (int i = 0; i < readText.Length; i++)
        {
            if ((readText[i] != ' ') && (i < readText.Length - 1))
            {
                oneWord = oneWord + readText[i];
            }
            else
            {
                words.Add(oneWord);
                oneWord = "";
            }
        }

        for (int i = 0; i < words.Count; i++)
        {
            // Removes unecessary symbols
            words[i] = Regex.Replace(words[i], @"(\s+|@|&|'|\(|\)|<|>|#|,|{|}|\[|\]|:)", "");
            if (words[i] == "\"content\"")
            {
                prices.Add(words[i + 1]);
                location++;
            }
        }

        // The prices in the output duplicate (the API scans the same text twice).
        // Therefore, only unique price values are left.
        // However, issues might arise when two different fuel types have the same price.
        // Changes will have to be made if that happens
        prices = prices.Distinct().ToList();

        // Outputs raw prices: 
        System.IO.File.AppendAllLines("rawPrices.json", prices);

        // Formats the prices:
        var count = prices.Count;
        for (int i = 0; i < count; i++)
        {
            int digitCount = 0;
            bool hasDigitalSeparator = false;
            for (int j = 0; j < prices[i].Length; j++)
            {
                if ((prices[i][j] > 47) && (prices[i][j] < 58))
                {
                    digitCount++;
                    if (digitCount > 4)
                    {
                        prices[i] = "";
                    }
                }
                else if (prices[i][j] == '.')
                {
                    hasDigitalSeparator = true;
                }
            }

            if ((hasDigitalSeparator == false) && (digitCount == 4))
            {
                prices[i] = prices[i].Insert(2, ".");
            }
            else if (digitCount < 3)
            {
                prices[i] = "";
            }
        }
        System.IO.File.AppendAllLines("prices.json", prices);
    }*/

    }
}

using BusinessLayer.Dtos;
using DataAccess.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngines
{
    class Program
    {
        private const string URI = "http://localhost:52683/api/Search/";
        public Program()
        {
        }
        static void Main(string[] args)
        {
            bool wordOpen = false;
            string content = "[";
            foreach (string arg in args)
            {
                bool quoteExists = arg.Contains("\"");
                if (quoteExists)
                {
                    if (wordOpen)
                    {
                        content += arg + "\",";
                        wordOpen = false;
                    }
                    else
                    {
                        content += "\"" + arg + " ";
                        wordOpen = true;
                    }
                }
                else
                {
                    if (wordOpen)
                    {
                        content += arg + " ";
                    }
                    else
                    {
                        content += "\"" + arg + "\",";
                    }
                }
            }
            content = content.Substring(0, content.Length - 1) + "]";
            StringContent postContent = new StringContent(content, Encoding.UTF8, "application/json");
            postContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient httpClient = new HttpClient();
            using (Task<HttpResponseMessage> response = httpClient.PostAsync(URI + "GetSearchsByLanguages", postContent))
            {
                response.Wait();
                HttpResponseMessage result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    List<LanguageSearchDto> languages = JsonConvert.DeserializeObject<List<LanguageSearchDto>>(readTask.Result);
                    if (languages.Count > 0)
                    {
                        Console.WriteLine("================================================");
                        Console.WriteLine("          PROGRAM LANGUAGES SEARCHS");
                        Console.WriteLine("================================================");

                        int maxLanguageSearchs = 0;
                        string maxLanguageSearchsName = "";
                        Guid[] languageIds = languages.Select(x => x.ProgramLanguageId.Value).Distinct().ToArray();
                        foreach (Guid languageId in languageIds)
                        {
                            List<LanguageSearchDto> languageSelecteds = languages.Where(x => x.ProgramLanguageId == languageId).OrderBy(x => x.EngineName).ToList();
                            int maxSearch = languageSelecteds.Select(x => x.CurrentSearchs.Value).Sum();
                            if (maxSearch > maxLanguageSearchs)
                            {
                                maxLanguageSearchs = maxSearch;
                                maxLanguageSearchsName = languageSelecteds.First().LanguageSearchName;
                            }
                            string message = languageSelecteds.First().LanguageSearchName;
                            foreach (LanguageSearchDto languageSelected in languageSelecteds)
                            {
                                message += $" {languageSelected.EngineName}: {languageSelected.CurrentSearchs}";
                            }
                            Console.WriteLine(message);
                        }

                        Console.WriteLine();
                        Console.WriteLine("================================================");
                        Console.WriteLine("               ENGINE WINNERS");
                        Console.WriteLine("================================================");
                        Guid[] engineIds = languages.Select(x => x.EngineId.Value).Distinct().ToArray();
                        foreach (Guid engineId in engineIds)
                        {
                            List<LanguageSearchDto> languageSelecteds = languages.Where(x => x.EngineId == engineId).ToList();
                            int maxSearch = languageSelecteds.Select(x => x.CurrentSearchs.Value).Max();
                            string message = languageSelecteds.First().EngineName + " Winner(s):";
                            foreach (LanguageSearchDto languageSelected in languageSelecteds)
                            {
                                if (languageSelected.CurrentSearchs == maxSearch)
                                {
                                    message += $" {languageSelected.LanguageSearchName}";
                                }
                            }
                            Console.WriteLine(message);
                        }

                        Console.WriteLine();
                        Console.WriteLine("================================================");
                        Console.WriteLine("               LANGUAGE WINNER");
                        Console.WriteLine("================================================");
                        Console.WriteLine($"Total Winner: {maxLanguageSearchsName}");
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron resultados para la búsqueda.");
                    }
                }
            }
        }
    }
}

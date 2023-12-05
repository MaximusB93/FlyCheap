using FlyCheap.Enums;
using FlyCheap.Models.Utils;
using FlyCheap.Utility;
using Newtonsoft.Json;

namespace FlyCheap.Api;

public class ApiForRequestDb
{
    private const string BaseUrl = "http://api.travelpayouts.com";
    public static string Russian => "ru/";
    public static string English => "en/";
    public static string Airports => "airports.json";
    public static string Countries => "countries.json";
    public static string Cities => "cities.json";
    public static string Airlines => "airlines.json";
    public static string Alliances => "alliances.json";
    public static string Planes => "planes.json"; //Данные в базе более не обновляются
    public static string Routes => "routes.json"; //Данные в базе более не обновляются

    /// <summary>
    /// Получение баз данных. 
    /// </summary>
    /// <param name="file"></param>
    /// <param name="tableCode">Выбор таблицы для обновления </param>
    /// <param name="language">Выбор языка. По умолчанию русский.</param>
    /// <typeparam name="TOutput"></typeparam> Всегда List! 
    /// <returns></returns>
    public TOutput? GetDataBase<TOutput>(TableCode tableCode,
        LanguageCode languageCode = LanguageCode.Russian /*string language = "ru/"*/)
        where TOutput : IEnumerable<NamedEntity>
    {
        //if (file is "planes.json" or "routes.json") language = "";

        var file = ParametersMap.TableFileMappings.FirstOrDefault(x => x.Key == tableCode)
            .Value; //Сверяем tableCode и записываем название json
        var lang = ParametersMap.LanguageMappings.FirstOrDefault(x => x.Key == languageCode)
            .Value; //Сверяем languageCode и записываем название json

        if (tableCode is TableCode.Planes or TableCode.Routes) //Если Planes или Routes, то lang = none
        {
            lang = ParametersMap.LanguageMappings.FirstOrDefault(x => x.Key == LanguageCode.None).Value;
        }

        //Записываем file и lang в экземпляр класса HttpRequestForRequestFromDataBase
        var RequestFromDataBase = new HttpRequestForRequestFromDataBase()
        {
            file = file,
            //language = language,
            language = lang,
        };

        var response =
            HttpRequest(RequestFromDataBase); // Делаем запрос к URL, сереализуем в строку и записываем в response
        if (response.Ok)
        {
            return ConvertFromJsonToDbFormat<TOutput>(response.content);  //Десериализация
        }

        Console.WriteLine("response.content ==> " + response.content);
        return default;
    }

    private ResponseContainer HttpRequest(HttpRequestForRequestFromDataBase httpRequest)
    {
        var url = $"{BaseUrl}/data/{httpRequest.language}{httpRequest.file}";
        var responseContainer = new ResponseContainer();

        using (var client = new HttpClient())
        {
            try
            {
                var response = client.GetAsync(url).Result; //Делаем запрос к url 

                if (response.IsSuccessStatusCode) //Проверям код ответа, если 200, то ок
                {
                    responseContainer.Ok = true;
                    responseContainer.content =
                        response.Content.ReadAsStringAsync()
                            .Result; //Сереализуем response и записываем в responseContainer 
                    //Console.WriteLine("content ===> " + content);
                }
                else //Если ошибка запроса
                {
                    Console.WriteLine("Ошибка запроса");
                    responseContainer.Ok = false;
                    responseContainer.content =
                        response.Content.ReadAsStringAsync()
                            .Result; //Сереализуем response и записываем в responseContainer 
                    //Console.WriteLine("content ===> " + content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка подключения: {ex.Message}");
            }

            return responseContainer;
        }
    }

    //Десериализация + замена значений name = null, на name="none"
    private TOutput? ConvertFromJsonToDbFormat<TOutput>(string input) where TOutput : IEnumerable<NamedEntity>
    {
        var output = JsonConvert.DeserializeObject<TOutput>(input); //Десериализуем в AirportJson/AirlinesJson и другие

        foreach (var item in output)
        {
            if (item.name == null)
            {
                item.name = "none"; // Заменяем значение поля name на пустую строку
            }
        }

        if (output.Any(x => x.name == null)) //Проверка  name == null
        {
            throw new InvalidOperationException("------>>>>Обнаружены объекты с полем name, равным null.");
        }

        // return default;
        return output;
    }
}
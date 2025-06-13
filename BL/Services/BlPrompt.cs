using BL.Api;
using DAL.Api;
using System.Net.Http.Headers;
using System.Text;

using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace BL.Services
{
    public class BlPromptService : IBLPrompt
    {
        IPrompt prompts;

        private static readonly HttpClient client = new HttpClient();
        public BlPromptService(IDal dal)
        {
            prompts = dal.prompt ?? throw new ArgumentNullException(nameof(dal.prompt), "The prompts object is null.");
        }

        public async Task<Prompt> AddPrompt(int user_id, int category_id, int sub_category_id, string prompt)
        {
            var allPrompts = await prompts.Read();
            var existingPrompt = allPrompts.FirstOrDefault(p => p.Prompt1 == prompt);
            if (existingPrompt != null)
            {
                // אם אתה לא הולך לשנות אותו – פשוט תחזיר אותו בלי לגעת ב־context
                return existingPrompt;
            }
            string aiResponse = await GetAIResponse(prompt);

            // כאן תוכל להוסיף לוגיקה לשמירה של הפרומפט עם התשובה מה-AI
            var random = new Random();
            var newPrompt = new Prompt
            {
                Id= random.Next(1, 1000000), 
                UserId = user_id,
                CategoryId = category_id,
                SubCategoryId = sub_category_id,
                Prompt1 = prompt,
                Response = aiResponse,
                CreatedAt = DateTime.Now
            };
            await prompts.Create(newPrompt);

            // החזרת הפרומפט החדש
            return newPrompt;
        }
        private async Task<string> GetAIResponse(string prompt)
        {
            var apiKey = "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"; // יש לשמור את המפתח בצורה בטוחה
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                model = "gpt-3.5-turbo-instruct",
                prompt = prompt,
                max_tokens = 150
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/completions", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"OpenAI API Error: {response.StatusCode} - {errorContent}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic? result = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);

            return result.choices[0].text.ToString().Trim();
        }
        public async Task<List<Prompt>> getUserPrompts(int id)
        {
            var allPrompts = await prompts.Read();
            return allPrompts.FindAll(p => p.UserId == id);
        }
        public string GetAIResponseDaeme(string prompt)
        {
            return $"response AI: answer for {prompt}";
        }
        public async Task<List<Prompt>> getAllPromptOrderByCategory()
        {
            var allPrompts = await prompts.Read();
            return allPrompts.OrderBy(p => p.CategoryId).ToList();
        }
    }
}



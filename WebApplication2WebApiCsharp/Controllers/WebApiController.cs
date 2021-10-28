using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;

namespace WebApplication2WebApiCsharp.Controllers
{
    //Controller is being created for each request.
    //Controller forward his data to a repository or a singleton object
    public class WebApiController : ApiController
    {
        private const string Success = "true";
        private const string Failure = "false";
        private const string SignForQuestionMark = "XXX";
        private const string SignForDotMark = "YYY";

        public Dictionary<string, bool> questions = new Dictionary<string, bool>{
            { "Was Aviv born in 1978?", false },// the sign "?" is a special character - we need to deal with it
            { "Was Aviv working in customer support?", true },
            { "Did Aviv publish 2 book?", true },
            { "Was Onassis granted the contract for Greek air transport industr?", true },
            { "Did he marry U.S. President John F. Kennedy widow?", true },
            { "Did Onassis died at the year 2000?", false },
            { "Was Athina Livanos Onassis's sister?", false }, // This fail beacuse ' can't be sent in url
            };

        #region Supports REST api


        private string UrlDecode(string str) {
            str = System.Web.HttpUtility.UrlDecode(str);
            str = str.Replace(SignForQuestionMark, "?");
            str = str.Replace(SignForDotMark, ".");
            
            return str;
        }

        [HttpGet]
        [ActionName("Yes")]
        public string GetIsYes(string info) {
            info = UrlDecode(info);
            if (questions.ContainsKey(info) == false) return Failure;
            return questions[info] == true ? Success : Failure;
        }

        [HttpGet]
        [ActionName("No")]
        public string GetIsNo(string info) {
            info = UrlDecode(info);
            if (info == "Is true?")
                return Success;
            else
                return Failure;
        }

        [HttpGet]
        [ActionName("RandomQuestion")]
        public string GetRandomQuestions() {
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int index = rand.Next(0, questions.Count);
            var enumerator = questions.Keys.GetEnumerator(); /*var = identify the class type from the result of =   */
            enumerator.MoveNext();
            for (int i = 0; i < index; i++) {
                enumerator.MoveNext();
            }
            var question = enumerator.Current;
            return question;

        }
        #endregion

       

    }
}
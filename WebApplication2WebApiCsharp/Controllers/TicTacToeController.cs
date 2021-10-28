using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2WebApiCsharp.Logic;

namespace WebApplication2WebApiCsharp.Controllers
{
    public class TicTacToeController : ApiController
    {

        [HttpGet]
        [ActionName("GetConnectStatus")]
        public bool GetConnectStatus([FromUri] string id) {
            return new System.Random().Next(0, 2) == 1;
        }

        [HttpGet]
        [ActionName("GetBoardState")]
        public string GetBoardState([FromUri] string id) {
            return TicTacToe.Instance.boardState;
        }

        [HttpGet]
        [ActionName("GetUserWon")]
        public string GetUserWon([FromUri] string id) {
            return new System.Random().Next(0, 50) == 0 ? id : "";
        }
        [HttpGet]
        [ActionName("GetUserTurn")]
        public string GetUserTurn([FromUri] string id) {
            return new System.Random().Next(0, 20) == 0 ? "" : id;
        }


        private string FakeState() {
            var rnd = new System.Random();
            var ret = "";
            for (int i = 0; i < 9; i++) {
                ret += "---ox"[rnd.Next(0, 5)]; 
            }
            return ret;
        }

        [HttpPost]
        [ActionName("PostTurnAction")]
        public IHttpActionResult PostTurnAction([FromUri] string id, [FromBody] string data) {
            TicTacToe.Instance.boardState = FakeState();
            return Ok(TicTacToe.Instance.boardState);//We can add return data in it but its not required
        }

        [HttpPost]
        [ActionName("PostDisconnect")]
        public IHttpActionResult PostDisconnect([FromUri] string id) {
            return BadRequest();
        }
    }
}
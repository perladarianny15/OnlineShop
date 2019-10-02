using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    //[Table("tblGames")]
    public class Game
    {
        public int GameID { get; set; }

        public string GameTittle { get; set; }

        public string GameCategory { get; set; }

        public string GameDetail { get; set; }
    }
}
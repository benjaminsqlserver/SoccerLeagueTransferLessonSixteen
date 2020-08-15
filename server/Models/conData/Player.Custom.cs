using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerLeagueTransferApp.Models.ConData
{
    public partial class Player
    {
        //read-only property fullname

        public string FullName => FirstName + " " + Surname;
        

    }
}

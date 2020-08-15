using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace SoccerLeagueTransferApp.Pages
{
    public partial class ConfirmDeletePlayerComponent
    {
        //custom method to delete a player
        private async Task MuyikDeletePlayer()
        {
            try
            {
                //call service layer method to delete player
                await ConData.DeletePlayer(PlayerID);
                //forcefully reload players list page
                UriHelper.NavigateTo("players", true);
            }
            catch(Exception)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Delete Player Error!", "An Error Occurred While Deleting Player", 5000);
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace SoccerLeagueTransferApp.Pages
{
    public partial class ConfirmDeleteClubDetailComponent
    {
        //custom method to delete a club

        private async Task MuyikDeleteClub()
        {
            
            try
            {
                //call delete club detail method in data service, I am passing in parameter TeamID which I set in the Club Detail list page
                await ConData.DeleteClubDetail(TeamID);

                //redirect to club detail list page

                UriHelper.NavigateTo("club-detail", true);



            }
            catch (Exception ex)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Club Detail Delete Error!", "An Error Occurred While Deleting This Club.Please Contact System Admin.", 5000);
            }
        }
    }
}

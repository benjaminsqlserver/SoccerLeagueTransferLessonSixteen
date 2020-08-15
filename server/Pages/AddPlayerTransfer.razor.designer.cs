using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using SoccerLeagueTransferApp.Models.ConData;
using Microsoft.EntityFrameworkCore;

namespace SoccerLeagueTransferApp.Pages
{
    public partial class AddPlayerTransferComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(() => { StateHasChanged(); });
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected ConDataService ConData { get; set; }

        List<SoccerLeagueTransferApp.Models.ConData.ClubDetail> _originatingClubList;
        protected List<SoccerLeagueTransferApp.Models.ConData.ClubDetail> originatingClubList
        {
            get
            {
                return _originatingClubList;
            }
            set
            {
                if (!object.Equals(_originatingClubList, value))
                {
                    _originatingClubList = value;
                    Reload();
                }
            }
        }

        IEnumerable<SoccerLeagueTransferApp.Models.ConData.Player> _getPlayersResult;
        protected IEnumerable<SoccerLeagueTransferApp.Models.ConData.Player> getPlayersResult
        {
            get
            {
                return _getPlayersResult;
            }
            set
            {
                if (!object.Equals(_getPlayersResult, value))
                {
                    _getPlayersResult = value;
                    Reload();
                }
            }
        }

        IEnumerable<SoccerLeagueTransferApp.Models.ConData.ClubDetail> _getClubDetailsResult;
        protected IEnumerable<SoccerLeagueTransferApp.Models.ConData.ClubDetail> getClubDetailsResult
        {
            get
            {
                return _getClubDetailsResult;
            }
            set
            {
                if (!object.Equals(_getClubDetailsResult, value))
                {
                    _getClubDetailsResult = value;
                    Reload();
                }
            }
        }

        IEnumerable<SoccerLeagueTransferApp.Models.ConData.TransferType> _getTransferTypesResult;
        protected IEnumerable<SoccerLeagueTransferApp.Models.ConData.TransferType> getTransferTypesResult
        {
            get
            {
                return _getTransferTypesResult;
            }
            set
            {
                if (!object.Equals(_getTransferTypesResult, value))
                {
                    _getTransferTypesResult = value;
                    Reload();
                }
            }
        }

        SoccerLeagueTransferApp.Models.ConData.PlayerTransfer _playertransfer;
        protected SoccerLeagueTransferApp.Models.ConData.PlayerTransfer playertransfer
        {
            get
            {
                return _playertransfer;
            }
            set
            {
                if (!object.Equals(_playertransfer, value))
                {
                    _playertransfer = value;
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }

        protected async System.Threading.Tasks.Task Load()
        {
            originatingClubList = new List<SoccerLeagueTransferApp.Models.ConData.ClubDetail>(){};

            await CheckUserStatus();

            getPlayersResult = new List<SoccerLeagueTransferApp.Models.ConData.Player>(){};

            var conDataGetClubDetailsResult = await ConData.GetClubDetails();
            getClubDetailsResult = conDataGetClubDetailsResult;

            var conDataGetTransferTypesResult = await ConData.GetTransferTypes();
            getTransferTypesResult = conDataGetTransferTypesResult;

            playertransfer = new SoccerLeagueTransferApp.Models.ConData.PlayerTransfer(){};

            await MuyikGetPlayerList();
        }

        protected async System.Threading.Tasks.Task Form0Submit(SoccerLeagueTransferApp.Models.ConData.PlayerTransfer args)
        {
            await MuyikTransferPlayer();
        }

        protected async System.Threading.Tasks.Task TransferDateChange(DateTime? args)
        {
            await ValidateTransferDate();
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}

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
    public partial class ConfirmDeleteUserComponent : ComponentBase
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

        [Parameter]
        public dynamic UserID { get; set; }

        SoccerLeagueTransferApp.Models.ConData.User _user;
        protected SoccerLeagueTransferApp.Models.ConData.User user
        {
            get
            {
                return _user;
            }
            set
            {
                if (!object.Equals(_user, value))
                {
                    _user = value;
                    Reload();
                }
            }
        }

        string _userRoleList;
        protected string userRoleList
        {
            get
            {
                return _userRoleList;
            }
            set
            {
                if (!object.Equals(_userRoleList, value))
                {
                    _userRoleList = value;
                    Reload();
                }
            }
        }

        IEnumerable<string> _userRoleNames;
        protected IEnumerable<string> userRoleNames
        {
            get
            {
                return _userRoleNames;
            }
            set
            {
                if (!object.Equals(_userRoleNames, value))
                {
                    _userRoleNames = value;
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
            await CheckUserStatus();

            var conDataGetUserByUserIdResult = await ConData.GetUserByUserId(UserID);
            user = conDataGetUserByUserIdResult;

            userRoleList = "";

            userRoleNames = new List<string>(){};

            await MuyikGetCurrentUserRoles();
        }

        protected async System.Threading.Tasks.Task Form0Submit(SoccerLeagueTransferApp.Models.ConData.User args)
        {
            await MuyikDeleteUser();
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            await MuyikCancel();
        }
    }
}

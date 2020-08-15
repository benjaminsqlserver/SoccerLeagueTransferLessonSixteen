using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SoccerLeagueTransferApp.Models.ConData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace SoccerLeagueTransferApp
{
    public partial class ConDataService
    {
        //method to validate user
        //takes in two parameters username and password

        public async Task<User> ValidateUser(string username,string password)
        {
            var user = new User();

            var user1 = context.Users.FirstOrDefault(p => p.Username == username && p.Password == password);

            if(user1!=null)
            {
                user = user1;
            }

            return await Task.FromResult(user);

        }

        public async Task<long> MuyikDeleteExistingUserRoles(int userID)
        {
            long rolesCount = 0;

            //get existing user roles from data store

            var existingUserRoles = context.UsersInRoles.Where(p => p.UserID == userID).ToList();
            if(existingUserRoles.Any())//checking if any userroles was returned
            {
                context.UsersInRoles.RemoveRange(existingUserRoles);//command to delete existing user roles
                context.SaveChanges();//persist changes to datastore
            }

            //get fresh count of user roles from data store

            rolesCount = context.UsersInRoles.Where(p => p.UserID == userID).ToList().Count;

            return rolesCount;
        }

        public async Task<User> MuyikGetUserByUserID(int userID)
        {
            var user = new User();

            var user1 = context.Users.Include("ClubDetail").FirstOrDefault(p => p.UserID==userID);

            if (user1 != null)
            {
                user = user1;
            }

            return await Task.FromResult(user);
        }

        public async Task<List<Player>> MuyikGetPlayers(int? teamID)
        {
            var players = new List<Player>();

            if(teamID==null)//site admin
            {
                players = await context.Players.ToListAsync();
            }
            else if(teamID !=null && teamID > 0)//club manager
            {
                players = await context.Players.Include("ClubDetail").Where(p => p.ClubDetail.TeamID == teamID).ToListAsync();
            }

            return await Task.FromResult(players);
        }

        public async Task MuyikChangePlayerClub(PlayerTransfer playertransfer)
        {
            //get the record of player being transferred
            var player = await context.Players.FirstOrDefaultAsync(p => p.PlayerID == playertransfer.PlayerID);

            if(player!=null)
            {
                player.CurrentClubID = playertransfer.DestinationClubID;//change players club to new club
               await context.SaveChangesAsync();

            }
        }

       

        public async Task<List<ClubDetail>> MuyikGetOriginatingClubList(int? teamID)
        {
            var list = new List<ClubDetail>();

            if (teamID == null)//site admin
            {
                list = await context.ClubDetails.ToListAsync();
            }
            else if (teamID != null && teamID > 0)//club manager
            {
                list = await context.ClubDetails.Where(p => p.TeamID == teamID).ToListAsync();
            }

            return await Task.FromResult(list);
        }

        public async Task MuyikResetPassword(int userID, string newPassword)
        {
            var user = context.Users.FirstOrDefault(p => p.UserID == userID);
            if(user.UserID > 0)//this implies that user is not null
            {
                user.Password = newPassword;
                context.SaveChanges();
            }
        }

        public async Task<Role> MuyikGetRoleByName(string roleName)
        {
            var role = new Role();

            try
            {
                var role1 = context.Roles.FirstOrDefault(p => p.RoleName == roleName);
                if(role1!=null && role1.RoleID > 0)
                {
                    role = role1;
                }
            }
            catch(Exception)
            {

            }

            return role;
        }

        public async Task MuyikChangeUserPassword(User user)
        {
            var user1 = context.Users.FirstOrDefault(p => p.UserID == user.UserID);
            if(user1!=null)//this implies that user was found in data store
            {
                user1.Password = user.Password;//change user password
                context.SaveChanges();//save changes to database
            }
        }

        public async Task MuyikSaveNewRoleList(List<UsersInRole> usersInRoles)
        {
            context.UsersInRoles.AddRange(usersInRoles);
        }

        public async Task<List<string>> MuyikGetRolesList(int userID)
        {
            var roles = new List<string>();

            var items = context.GetUserRoles.FromSqlRaw("EXEC [dbo].[GetUserRoles] @UserID={0}", userID).ToList();

            if(items.Any())
            {
                foreach(GetUserRole item in items)
                {
                    if(!string.IsNullOrEmpty(item.RoleName))
                    {
                        roles.Add(item.RoleName);
                    }
                }
            }

            return await Task.FromResult(roles);
        }

        public async Task<List<UsersInRole>> MuyikGetExistingUserRoles(int userID)
        {
            var list = new List<UsersInRole>();

            //get existing user roles from data store

            var existingUserRoles = context.UsersInRoles.Include("Role").Where(p => p.UserID == userID).ToList();
            
                list = existingUserRoles;//point existingUserRoles reference to list reference


            return await Task.FromResult(list);
        }

        public async Task<User> MuyikGetUserByEmail(string emailAddress)
        {
            var user = new User();

            var user1 = context.Users.FirstOrDefault(p => p.EmailAddress==emailAddress);

            if (user1 != null)
            {
                user = user1;
            }

            return await Task.FromResult(user);
        }
    }
}

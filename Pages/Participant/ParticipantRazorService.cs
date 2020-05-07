using ConferenceApp.Helpers;
using ConferenceApp.Services;
using ConferenceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace ConferenceApp.Pages.Participant
{
    public class ParticipantRazorService
    {   
        protected readonly IParticipantService _participantService;
        protected readonly NavigationManager _navigationManager;

        public ParticipantRazorService(
            IParticipantService participantService,
            NavigationManager navigationManager)
        {
            _participantService = participantService;
            _navigationManager = navigationManager;
        }
        [Flags]
        public enum SortDirections
        {
            ASC,
            DESC
        } 

    [Flags]
        public enum SortByFields
        {
            NAME,
            EMAIL,
            COMPANY,
            POSITION,
            COUNTRY,
            REGISTRATION_DATE,
            STATUS
        } 

        public PaginatedList<Models.Participant> Participants { get; private set; }
        public SortByFields SortBy { get; private set; }
        public SortDirections SortDirection { get; private set; }
        public int TotalPages { get; private set; }
        public int CurrentPage { get; private set; } = 1;

        public event Action OnChange;

        public void FetchParticipants(int? page)
        {
            var nextPage = page ?? CurrentPage;
            Participants = _participantService.PaginatedList(nextPage);
            TotalPages = Participants.TotalPages;
            CurrentPage = Participants.CurrentPage;
            NotifyStateChanged();
        }

        private void ParseArguments(Dictionary<string, Microsoft.Extensions.Primitives.StringValues> query)
        {
            if (query != null && query.TryGetValue("sortBy", out var sortByParam))
            {
                SortBy = (SortByFields)Enum.Parse(typeof(SortByFields), sortByParam.First(), true);
            }

            if (query != null && query.TryGetValue("sortDirection", out var sortDirectionParam))
            {
                SortDirection = (SortDirections)Enum.Parse(typeof(SortDirections), sortDirectionParam.First(), true);
            }
        }

        public void ParseQueryString()
        {
            var uri = _navigationManager.ToAbsoluteUri(_navigationManager.Uri);
            var query = QueryHelpers.ParseNullableQuery(uri.Query);

            try
            {
                this.ParseArguments(query);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR {error}", e.Source);
                throw;
            }

        }

        private void NotifyStateChanged() => OnChange?.Invoke();

    }
}

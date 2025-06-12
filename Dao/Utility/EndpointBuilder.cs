using Dao.Enums;

namespace Dao.Utilitly
{
    public static class EndpointBuilder
    {
        private const string BaseUrl = "https://worldcup-vua.nullbit.hr";

        private static string GenderToSegment(GenderType gender)
        {
            return gender switch
            {
                GenderType.Male => "men",
                GenderType.Female => "women",
                _ => throw new ArgumentOutOfRangeException(nameof(gender), "Unsupported gender type.")
            };
        }

        public static string BuildTeamsEndpoint(GenderType gender) =>
            $"{BaseUrl}/{GenderToSegment(gender)}/teams";

        public static string BuildTeamResultsEndpoint(GenderType gender) =>
            $"{BuildTeamsEndpoint(gender)}/results";

        public static string BuildMatchesEndpoint(GenderType gender) =>
            $"{BaseUrl}/{GenderToSegment(gender)}/matches";

        public static string BuildCountryMatchesEndpoint(GenderType gender, string fifaCode) =>
            $"{BuildMatchesEndpoint(gender)}/country?fifa_code={fifaCode.ToUpper()}";
    }
}


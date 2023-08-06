namespace JobSeekAPI.Services
{
    public class DbService
    {
        public db_a8b602_jobseekContext _context;

        public DbService(db_a8b602_jobseekContext context)
        {
            _context = context;
        }

        public int SelectCityId(int UserId)
        {
            var Id = from User in _context.Users
                     where User.Id == UserId
                     select User.CityId;

            if (Id.Count() == 0)
            {
                return 0;
            }
            return (int)Id.First();
        }
        public int SelectCityId(string CityName)
        {
            var Id = from City in _context.Cities
                     where City.Name == CityName
                     select City.Id;

            if (Id.Count() == 0)
            {
                return 0;
            }
            return Id.First();
        }
        public async Task<int> SelectBranchSectionId(string CityName)
        {
            var cityId = await _context.Cities
                .Where(c => c.Name == CityName)
                .Select(c => c.Id).FirstAsync();
            var branchId = await _context.Branches
                .Where(b => b.CityId == cityId)
                .Select(b => b.Id).FirstAsync();
            var branchSectionId = await _context.BranchSections
                .Where(bs => bs.BranchId == branchId)
                .Select(bs => bs.Id).FirstAsync();

            return branchSectionId;
        }
    }
}

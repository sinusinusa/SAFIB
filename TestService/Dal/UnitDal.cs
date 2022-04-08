using TestService.DataAccess.Entity;

namespace B.Dto
{
    public class UnitDal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? MainId { get; set; }


        public static UnitDal FromUnit(Unit unit)
        {
            var unitDal = new UnitDal();
            unitDal.Id = unit.Id;
            unitDal.Name = unit.Name;
            unitDal.MainId = unit.MainId;
            return unitDal;
        }
    }
}

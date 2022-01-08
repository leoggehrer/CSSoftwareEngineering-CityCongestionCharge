namespace CityCongestionCharge.Logic.Controllers
{
    public partial class CarController : GenericController<Entities.Car>
    {
        public CarController()
        {
        }

        public CarController(ControllerObject other) : base(other)
        {
        }
    }
}

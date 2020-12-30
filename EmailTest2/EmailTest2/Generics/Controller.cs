using Microsoft.AspNetCore.Mvc;


namespace EmailingProject.Generics
{
    public class Controller : ControllerBase
    {
        protected MessageCollection messageCollection = new MessageCollection();
    }
}

using CardPortal.API.Controllers.BaseAPI;
using CardPortal.Application.Command.User;
using CardPortal.Application.Query.User;
using CardPortal.Domain.Dto.User;
using CardPortal.Domain.Dto.User.Login;
using CardPortal.Domain.Dto.User.Profile;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers
{
    public class UserController : BaseAPIController
    {
        #region UserActions

        [HttpPost]
        public async Task<ActionResult> Login(LoginDto login)
        {
            try
            {
                return Ok(await Mediator.Send(new LoginCommand(login)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion UserActions

        #region ProfileActions

        [HttpPost]
        public async Task<ActionResult> ChangeUsername(int userId, string newUsername)
        {
            try
            {
                return Ok(await Mediator.Send(new ChangeUsernameCommand(userId, newUsername)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ChangeName(ChangeNameDto changeName)
        {
            try
            {
                return Ok(await Mediator.Send(new ChangeNameCommand(changeName)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordDto changePassword)
        {
            try
            {
                return Ok(await Mediator.Send(new ChangePasswordCommand(changePassword)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RequestNewPassword(string username)
        {
            try
            {
                return Ok(await Mediator.Send(new RequestNewPasswordCommand(username)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion ProfileActions

        #region AdminActions

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllUsersQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetUserQuery(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUserByUsername(string username)
        {
            try
            {
                return Ok(await Mediator.Send(new GetUserByUsernameQuery(username)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserWriteDto user)
        {
            try
            {
                return Ok(await Mediator.Send(new CreateUserCommand(user)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(UserWriteDto user)
        {
            try
            {
                return Ok(await Mediator.Send(new UpdateUserCommand(user)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(UserWriteDto user)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteUserCommand(user)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion AdminActions
    }
}

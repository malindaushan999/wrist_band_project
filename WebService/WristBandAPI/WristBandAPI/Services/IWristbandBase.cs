using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WristBandAPI.Base;
using WristBandAPI.Common;

namespace WristBandAPI.Services
{
	[ServiceContract]
	public interface IWristbandBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[OperationContract(Name = "Login", Action = "/LoginReq", ReplyAction = "/LoginRes")]
		LoginResponse Login(LoginRequest req);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[Inspector]
		[OperationContract(Name = "Logout", Action = "/LogoutReq", ReplyAction = "/LogoutRes")]
		LogoutResponse Logout(LogoutRequest req);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[OperationContract(Name = "RegisterUser", Action = "/RegisterUserReq", ReplyAction = "/RegisterUserRes")]
		RegisterUserResponse RegisterUser(RegisterUserRequest req);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[Inspector]
		[OperationContract(Name = "ForgotPassword", Action = "/ForgotPasswordReq", ReplyAction = "/ForgotPasswordRes")]
		ForgotPasswordResponseResponse ForgotPassword(ForgotPasswordRequestRequest req);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[Inspector]
		[OperationContract(Name = "VerifySignUpToken", Action = "/VerifySignUpTokenReq", ReplyAction = "/VerifySignUpTokenRes")]
		VerifySignUpTokenResponse VerifySignUpToken(VerifySignUpTokenRequest req);

		///// <summary>
		///// 
		///// </summary>
		///// <param name="req"></param>
		///// <returns></returns>
		[Inspector]
		[OperationContract(Name = "ChangePassword", Action = "/ChangePasswordReq", ReplyAction = "/ChangePasswordRes")]
		ChangePasswordResponse ChangePassword(ChangePasswordRequest req);

		/// <summary>
		/// Author: Malinda Ushan
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[Inspector]
		[OperationContract(Name = "UpdateUser", Action = "/UpdateUserReq", ReplyAction = "/UpdateUserRes")]
		UpdateUserResponse UpdateUser(UpdateUserRequest req);

		/// <summary>
		/// Author: Malinda Ushan
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[Inspector]
		[OperationContract(Name = "UpdateUserPassword", Action = "/UpdateUserPasswordReq", ReplyAction = "/UpdateUserPasswordRes")]
		UpdateUserPasswordResponse UpdateUserPassword(UpdateUserPasswordRequest req);

		/// <summary>
		/// Author: Sanuja Lavi
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[OperationContract(Name = "VerifyUserAccount", Action = "/VerifyUserAccountReq", ReplyAction = "/VerifyUserAccountRes")]
		VerifyUserAccountResponse VerifyUserAccount(VerifyUserAccountRequest req);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[Inspector]
		[OperationContract(Name = "GetBTData", Action = "/GetBTDataReq", ReplyAction = "/GetBTDataRes")]
		GetBTDataResponse GetBTData(GetBTDataRequest req);
	}
}

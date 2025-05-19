using AuthServiceGrpcServer;
using Grpc.Core;

namespace Presentation.Services;

public class AuthServiceProtoService : AuthServiceProto.AuthServiceProtoBase
{
    public override async Task<SignUpResponse> SignUp(SignUpRequest request, ServerCallContext context)
    {
        if (request.Password != request.ConfirmPassword)
        {
            return await Task.FromResult(new SignUpResponse
            {
                Success = false,
                Message = "Passwords do not match"
            });
        }

        Console.WriteLine($"User created: {request.Email}");

        return await Task.FromResult(new SignUpResponse
        {
            Success = true,
            Message = "User created successfully"
        });
    }
}

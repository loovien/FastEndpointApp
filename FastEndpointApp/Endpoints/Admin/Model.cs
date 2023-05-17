namespace FastEndpointApp.Endpoints.Admin;

record class UserRequest(string mobile, string password);

record class UserResponse(string username, int age);
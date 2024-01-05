using DotNetEnv;

namespace WebApiSample {
  public class JwtKey {
    public static string? Secret { get; set; }

    static JwtKey() {
      Env.Load();
      Secret = Environment.GetEnvironmentVariable("SECRET_JWT");
    }
  }
}
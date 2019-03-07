namespace Sitecore.Support.Owin.Authentication.Pipelines.CookieAuthentication.SignedIn
{
  using System;
  using Sitecore.Diagnostics;
  using Sitecore.Owin.Authentication.Identity;
  using Sitecore.Owin.Authentication.Pipelines.CookieAuthentication.SignedIn;

  public class UpdateStatistics : SignedInProcessor
  {
    private IMembership _membership;

    public UpdateStatistics(IMembership membership)
    {
      Assert.ArgumentNotNull(membership, nameof(membership));

      _membership = membership;
    }

    public override void Process(SignedInArgs args)
    {
      var user = _membership.GetUser(args.User.UserName);
      if (user == null)
      {
        return;
      }

      // here we can change  user last login statistics and so on.
      user.LastLoginDate = DateTime.Now;
      _membership.UpdateUser(user);
    }
  }
}
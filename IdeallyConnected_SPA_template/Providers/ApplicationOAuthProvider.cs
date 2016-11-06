using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace IdeallyConnected_SPA_template.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if(publicClientId == null) {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        /*
        Called to validate that the context.ClientId is a registered "client_id", and that the context.RedirectUri 
        a "redirect_uri" registered for that client. This only occurs when processing the Authorize endpoint. The application 
        MUST implement this call, and it MUST validate both of those factors before calling context.Validated. If the 
        context.Validated method is called with a given redirectUri parameter, then IsValidated will only become true if the
        incoming redirect URI matches the given redirect URI. If context.Validated is not called the request will not proceed further.
        */
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if(context.ClientId == _publicClientId) {
                Uri expectedRootUri = new Uri(context.Request.Uri,"/");

                if(expectedRootUri.AbsoluteUri == context.RedirectUri) {
                    context.Validated();
                }
                else if(context.ClientId == "web") {
                    var expectedUri = new Uri(context.Request.Uri,"/");
                    context.Validated(expectedUri.AbsoluteUri);
                }
            }

            return Task.FromResult<object>(null);
        }
    }
}
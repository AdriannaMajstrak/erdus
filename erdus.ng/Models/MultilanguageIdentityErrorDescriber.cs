using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.Models
{
    public class MultilanguageIdentityErrorDescriber : IdentityErrorDescriber
    {
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a concurrency
        //     failure.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a concurrency failure.
        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError()
            {
                Description = "Ten rekord został zmienony przez innego użytkownika"
            };
        }

        //
        // Summary:
        //     Returns the default Microsoft.AspNetCore.Identity.IdentityError.
        //
        // Returns:
        //     The default Microsoft.AspNetCore.Identity.IdentityError.
        public override IdentityError DefaultError()
        {
            return new IdentityError()
            {
                Description = "Wpisano złą wartość"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating the specified
        //     email is already associated with an account.
        //
        // Parameters:
        //   email:
        //     The email that is already associated with an account.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating the specified email
        //     is already associated with an account.
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Description = "Taki adres email już istnieje w bazie"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating the specified
        //     role name already exists.
        //
        // Parameters:
        //   role:
        //     The duplicate role.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating the specific role role
        //     name already exists.
        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError()
            {
                Description = "Taka rola o takiej nazwie już istnieje w bazie"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating the specified
        //     userName already exists.
        //
        // Parameters:
        //   userName:
        //     The user name that already exists.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating the specified userName
        //     already exists.
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Description = "Taki użytkownik już istnieje"
            };
        }

        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating the specified
        //     email is invalid.
        //
        // Parameters:
        //   email:
        //     The email that is invalid.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating the specified email
        //     is invalid.
        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError()
            {
                Description = "Nieprawidłowy adres email"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating the specified
        //     role name is invalid.
        //
        // Parameters:
        //   role:
        //     The invalid role.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating the specific role role
        //     name is invalid.
        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError()
            {
                Description = "Nieprawidłowa nazwa roli"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating an invalid
        //     token.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating an invalid token.
        public override IdentityError InvalidToken()
        {
            return new IdentityError()
            {
                Description = "Sesja wygasła"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating the specified
        //     user userName is invalid.
        //
        // Parameters:
        //   userName:
        //     The user name that is invalid.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating the specified user
        //     userName is invalid.
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError()
            {
                Description = "Nieprawidłowa nazwa użytkownika"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating an external
        //     login is already associated with an account.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating an external login is
        //     already associated with an account.
        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError()
            {
                Description = "Login jest już powiązany z kontem"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a password
        //     mismatch.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a password mismatch.
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError()
            {
                Description = "Hasło nie pasuje"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a password
        //     entered does not contain a numeric character, which is required by the password
        //     policy.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a password entered
        //     does not contain a numeric character.
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Description = "Hasło powinno zawierać przynamniej jedną cyfrę"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a password
        //     entered does not contain a lower case letter, which is required by the password
        //     policy.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a password entered
        //     does not contain a lower case letter.
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Description = "Hasło powinno zawierać przynamniej jedną małą literę"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a password
        //     entered does not contain a non-alphanumeric character, which is required by the
        //     password policy.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a password entered
        //     does not contain a non-alphanumeric character.
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Description = "Hasło powinno zawierać przynamniej jeden znak niealfanumeryczny"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a password
        //     does not meet the minimum number uniqueChars of unique chars.
        //
        // Parameters:
        //   uniqueChars:
        //     The number of different chars that must be used.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a password does not
        //     meet the minimum number uniqueChars of unique chars.
        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError()
            {
                Description = "Hasło jest za słabe"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a password
        //     entered does not contain an upper case letter, which is required by the password
        //     policy.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a password entered
        //     does not contain an upper case letter.
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Description = "Hasło powinno zawierać przynamniej jedną dużą literę"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a password
        //     of the specified length does not meet the minimum length requirements.
        //
        // Parameters:
        //   length:
        //     The length that is not long enough.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a password of the specified
        //     length does not meet the minimum length requirements.
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Description = "Hasło jest za krótkie"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a recovery
        //     code was not redeemed.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a recovery code was
        //     not redeemed.
        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError()
            {
                Description = "Nie można odyzkać hasła, skontaktuj się z administratorem"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a user already
        //     has a password.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a user already has
        //     a password.
        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError()
            {
                Description = "Ten użytkownik ma już hasło"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a user is already
        //     in the specified role.
        //
        // Parameters:
        //   role:
        //     The duplicate role.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a user is already in
        //     the specified role.
        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError()
            {
                Description = "Użytkownik ma już przypisaną tę rolę"
            };
        }
        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating user lockout
        //     is not enabled.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating user lockout is not
        //     enabled.
        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError()
            {
                Description = "Blokowanie użytkownika nie zostalo włączone"
            };
        }

        //
        // Summary:
        //     Returns an Microsoft.AspNetCore.Identity.IdentityError indicating a user is not
        //     in the specified role.
        //
        // Parameters:
        //   role:
        //     The duplicate role.
        //
        // Returns:
        //     An Microsoft.AspNetCore.Identity.IdentityError indicating a user is not in the
        //     specified role.
        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError()
            {
                Description = "Użytkownik nie jest przypisany do tej roli"
            };
        }

    }
}

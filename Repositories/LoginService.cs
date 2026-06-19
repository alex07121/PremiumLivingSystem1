using System;
using BCrypt.Net;
using PremiumLivingSystem.Models;
using PremiumLivingSystem.Repositories;

namespace PremiumLivingSystem.Services
{
    /// <summary>
    /// Login service (business logic layer)
    /// </summary>
    public class LoginService
    {
        private readonly IStaffRepository _staffRepository;

        /// <summary>
        /// Constructor (dependency injection)
        /// </summary>
        /// <param name="staffRepository">Staff Repository (mock objects can be injected for testing)</param>
        public LoginService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository ?? throw new ArgumentNullException(nameof(staffRepository));
        }

        /// <summary>
        /// Validate login credentials
        /// </summary>
        /// <param name="staffId">Account (Staff ID)</param>
        /// <param name="password">Password (plaintext)</param>
        /// <returns>Returns Staff object on successful login, null on failure</returns>
        public Staff Authenticate(string staffId, string password)
        {
            // 1. Retrieve staff record (including PasswordHash)
            var staff = _staffRepository.GetByStaffId(staffId);

            if (staff == null)
            {
                return null; // Account does not exist
            }

            // 2. Verify password (using BCrypt)
            bool passwordValid = BCrypt.Net.BCrypt.Verify(password, staff.PasswordHash);

            if (!passwordValid)
            {
                return null; // Incorrect password
            }

            // 3. Login successful: return Staff object (excluding PasswordHash)
            return staff;
        }
    }
}
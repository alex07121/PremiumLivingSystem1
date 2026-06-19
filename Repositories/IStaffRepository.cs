using System.Collections.Generic;
using PremiumLivingSystem.Models;

namespace PremiumLivingSystem.Repositories
{
    /// <summary>
    /// Staff data access interface (abstraction layer)
    /// </summary>
    public interface IStaffRepository
    {
        /// <summary>
        /// Get staff record by StaffID (including PasswordHash)
        /// </summary>
        Staff GetByStaffId(string staffId);

        /// <summary>
        /// Get all staff list
        /// </summary>
        List<Staff> GetAllStaff();

        /// <summary>
        /// Add a new staff member
        /// </summary>
        bool AddStaff(Staff staff);

        /// <summary>
        /// Update staff information
        /// </summary>
        bool UpdateStaff(Staff staff);

        /// <summary>
        /// Delete a staff member
        /// </summary>
        bool DeleteStaff(string staffId);
    }
}
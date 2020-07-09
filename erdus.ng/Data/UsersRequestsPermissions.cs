namespace erdus.ng.Data
{
    public class UsersRequestsPermissions
    {
        public UsersRequestsPermissions()
        {
        }

        public UsersRequestsPermissions(bool canEdit, bool canDelete, bool canChangeResponsiblePerson, bool canChangeStatus)
        {
            CanEdit = canEdit;
            CanDelete = canDelete;
            CanChangeResponsiblePerson = canChangeResponsiblePerson;
            CanChangeStatus = canChangeStatus;
        }

        public bool CanEdit { get; }
        public bool CanDelete { get; }
        public bool CanChangeResponsiblePerson { get; }
        public bool CanChangeStatus { get; }
    }
}

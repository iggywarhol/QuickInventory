using SimpleInventory.Models;

namespace SimpleInventory.Interfaces
{
    interface ICreatedEditedItemType
    {
        void CreatedEditedItemType(bbItemType itemType, bool wasCreated);
    }
}

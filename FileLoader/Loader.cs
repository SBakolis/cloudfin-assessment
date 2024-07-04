using System.Collections.Generic;
using System.Linq;

namespace FileLoader
{
    public sealed class Loader
    {
        private static List<Supplier> suppliers = new List<Supplier>()
        {
            new Supplier
            {
                Id = "1",
                Address = "Add1",
                Name = "Supp1"
            },
            new Supplier
            {
                Id = "2",
                Address = "Add2",
                Name = "Supp2"
            },
            new Supplier
            {
                Id = "3",
                Address = "Add3",
                Name = "Supp3"
            }
        };

        private readonly string filePath;

        public Loader(string filePath)
        {
            this.filePath = filePath;
        }

        public Supplier LoadSupplier(string id)
        {
            CheckPath();

            var supplier = suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null) throw new ApiException("Supplier not found", 1);

            return supplier;
        }

        public IEnumerable<Supplier> LoadSuppliers()
        {
            CheckPath();

            return suppliers;
        }

        public void InsertSupplier(Supplier supplier)
        {
            CheckPath();

            if (string.IsNullOrWhiteSpace(supplier.Id) || string.IsNullOrWhiteSpace(supplier.Name)) throw new ApiException("Id and name are required", 2);

            var dbSupplier = suppliers.FirstOrDefault(s => s.Id == supplier.Id);
            if (dbSupplier != null) throw new ApiException("Supplier already exists", 3);

            suppliers.Add(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            CheckPath();

            var dbSupplier = suppliers.FirstOrDefault(s => s.Id == supplier.Id);
            if (dbSupplier == null) throw new ApiException("Supplier not found", 1);

            dbSupplier.Name = supplier.Name;
            dbSupplier.Address = supplier.Address;
        }

        public void DeleteSupplier(string id)
        {
            CheckPath();

            var supplier = suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null) throw new ApiException("Supplier not found", 1);

            suppliers.Remove(supplier);
        }

        private void CheckPath()
        {
            if (filePath.ToLower() != "suppliers.txt") throw new ApiException("File not found", 5);
        }
    }
}

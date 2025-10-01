using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBurguerValueRCL.Services
{
    namespace SmartBurguerValueRCL.Services
    {
        public class EnterpriseProvider
        {
            private Guid? _enterpriseId;
            private TaskCompletionSource<Guid> _tcs = new();

            public event Action<Guid>? OnEnterpriseChanged;

            public Task SetEnterpriseId(Guid id)
            {
                _enterpriseId = id;
                _tcs.TrySetResult(id);
                OnEnterpriseChanged?.Invoke(id);

                return Task.CompletedTask;
            }

            public Task<Guid> GetEnterpriseIdAsync()
            {
                if (_enterpriseId.HasValue)
                    return Task.FromResult(_enterpriseId.Value);

                return _tcs.Task;
            }

            public void Clear()
            {
                _enterpriseId = null;
                _tcs = new TaskCompletionSource<Guid>();
            }
        }
    }


}

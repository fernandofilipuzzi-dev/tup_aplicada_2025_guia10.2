
namespace GeometriaListDALsImpl.Utilities;

public class ListTransaction
{
    private bool _isCommitted;
    private bool _isRolledBack;
    private readonly List<object> _originalList;
    private List<object> _workingCopy;

    public ListTransaction(List<object> figuras)
    {
        _isCommitted = false;
        _isRolledBack = false;
        _originalList = figuras;
        _workingCopy = new List<object>(_originalList);
    }

    public List<object> GetWorkingCopy() => _workingCopy;

    public void Commit()
    {
        if (_isRolledBack)
            throw new InvalidOperationException("Transaction has been rolled back.");
        if (_isCommitted)
            throw new InvalidOperationException("Transaction has already been committed.");

        _originalList.Clear();
        _originalList.AddRange(_workingCopy);
        _isCommitted = true;
    }

    public void Rollback()
    {
        if (_isCommitted)
            throw new InvalidOperationException("Transaction has already been committed.");
        if (_isRolledBack)
            throw new InvalidOperationException("Transaction has already been rolled back.");

        _workingCopy = new List<object>(_originalList);
        _isRolledBack = true;
    }

    public bool IsCommitted => _isCommitted;
    public bool IsRolledBack => _isRolledBack;
}
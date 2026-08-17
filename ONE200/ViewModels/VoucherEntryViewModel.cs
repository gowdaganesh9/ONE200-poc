using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ONE200.ViewModels;

public sealed class VoucherLineItem : INotifyPropertyChanged
{
    private bool _selected;
    private string _position = string.Empty;
    private string _accountNo = string.Empty;
    private string _accountName = string.Empty;
    private string _costCenter = string.Empty;
    private string _taxCode = string.Empty;
    private decimal _amountSc;
    private decimal _amountFc;
    private string _text = string.Empty;
    private string _status = string.Empty;

    public bool Selected
    {
        get => _selected;
        set { _selected = value; OnPropertyChanged(); }
    }

    public string Position
    {
        get => _position;
        set { _position = value; OnPropertyChanged(); }
    }

    public string AccountNo
    {
        get => _accountNo;
        set { _accountNo = value; OnPropertyChanged(); }
    }

    public string AccountName
    {
        get => _accountName;
        set { _accountName = value; OnPropertyChanged(); }
    }

    public string CostCenter
    {
        get => _costCenter;
        set { _costCenter = value; OnPropertyChanged(); }
    }

    public string TaxCode
    {
        get => _taxCode;
        set { _taxCode = value; OnPropertyChanged(); }
    }

    public decimal AmountSc
    {
        get => _amountSc;
        set { _amountSc = value; OnPropertyChanged(); }
    }

    public decimal AmountFc
    {
        get => _amountFc;
        set { _amountFc = value; OnPropertyChanged(); }
    }

    public string Text
    {
        get => _text;
        set { _text = value; OnPropertyChanged(); }
    }

    public string Status
    {
        get => _status;
        set { _status = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

public sealed class TransferGroupNode
{
    public string DisplayName { get; set; } = string.Empty;
    public bool IsSelected { get; set; }
}

public sealed class VoucherEntryViewModel : INotifyPropertyChanged
{
    // ── Filter panel ──────────────────────────────────────────────────────────

    private string? _selectedTransferType;
    private string? _selectedTransferPeriod;
    private string? _selectedTransferStatus;
    private string? _selectedStatusTo;

    public List<string> TransferTypes { get; } = new() { "All", "Incoming", "Outgoing" };
    public List<string> TransferPeriods { get; } = new() { "Current month", "Last month", "Current year" };
    public List<string> TransferStatuses { get; } = new() { "All", "Open", "Posted", "Cancelled" };
    public List<string> StatusToOptions { get; } = new() { "All", "Posted", "Cancelled" };

    public string? SelectedTransferType
    {
        get => _selectedTransferType;
        set { _selectedTransferType = value; OnPropertyChanged(); }
    }

    public string? SelectedTransferPeriod
    {
        get => _selectedTransferPeriod;
        set { _selectedTransferPeriod = value; OnPropertyChanged(); }
    }

    public string? SelectedTransferStatus
    {
        get => _selectedTransferStatus;
        set { _selectedTransferStatus = value; OnPropertyChanged(); }
    }

    public string? SelectedStatusTo
    {
        get => _selectedStatusTo;
        set { _selectedStatusTo = value; OnPropertyChanged(); }
    }

    public ObservableCollection<TransferGroupNode> TransferGroups { get; } = new();

    private TransferGroupNode? _selectedTransferGroup;
    public TransferGroupNode? SelectedTransferGroup
    {
        get => _selectedTransferGroup;
        set { _selectedTransferGroup = value; OnPropertyChanged(); }
    }

    // ── Voucher header ────────────────────────────────────────────────────────

    private string? _selectedSupplierType;
    private string _supplierNo = string.Empty;
    private string _currencyId = string.Empty;
    private string _currencyCode = string.Empty;
    private decimal _exchangeRate;
    private bool _isNetAmount = true;
    private bool _isGross;
    private bool _finalPosting;
    private string _sortNumber = string.Empty;
    private string _numberName = string.Empty;
    private DateTime? _issueDate;
    private DateTime? _entryDate;
    private decimal _amountSc;
    private decimal _amountFc;
    private string _telephone = string.Empty;
    private int _numberOfPositions;
    private string _vatEditionNote = string.Empty;
    private string _voucherNumber = string.Empty;
    private string _voucherName = string.Empty;

    public List<string> SupplierTypes { get; } = new() { "Supplier", "Customer", "Employee" };

    public string? SelectedSupplierType
    {
        get => _selectedSupplierType;
        set { _selectedSupplierType = value; OnPropertyChanged(); }
    }

    public string SupplierNo
    {
        get => _supplierNo;
        set { _supplierNo = value; OnPropertyChanged(); }
    }

    public string CurrencyId
    {
        get => _currencyId;
        set { _currencyId = value; OnPropertyChanged(); }
    }

    public string CurrencyCode
    {
        get => _currencyCode;
        set { _currencyCode = value; OnPropertyChanged(); }
    }

    public decimal ExchangeRate
    {
        get => _exchangeRate;
        set { _exchangeRate = value; OnPropertyChanged(); }
    }

    public bool IsNetAmount
    {
        get => _isNetAmount;
        set { _isNetAmount = value; OnPropertyChanged(); }
    }

    public bool IsGross
    {
        get => _isGross;
        set { _isGross = value; OnPropertyChanged(); }
    }

    public bool FinalPosting
    {
        get => _finalPosting;
        set { _finalPosting = value; OnPropertyChanged(); }
    }

    public string SortNumber
    {
        get => _sortNumber;
        set { _sortNumber = value; OnPropertyChanged(); }
    }

    public string NumberName
    {
        get => _numberName;
        set { _numberName = value; OnPropertyChanged(); }
    }

    public DateTime? IssueDate
    {
        get => _issueDate;
        set { _issueDate = value; OnPropertyChanged(); }
    }

    public DateTime? EntryDate
    {
        get => _entryDate;
        set { _entryDate = value; OnPropertyChanged(); }
    }

    public decimal AmountSc
    {
        get => _amountSc;
        set { _amountSc = value; OnPropertyChanged(); }
    }

    public decimal AmountFc
    {
        get => _amountFc;
        set { _amountFc = value; OnPropertyChanged(); }
    }

    public string Telephone
    {
        get => _telephone;
        set { _telephone = value; OnPropertyChanged(); }
    }

    public int NumberOfPositions
    {
        get => _numberOfPositions;
        set { _numberOfPositions = value; OnPropertyChanged(); }
    }

    public string VatEditionNote
    {
        get => _vatEditionNote;
        set { _vatEditionNote = value; OnPropertyChanged(); }
    }

    public string VoucherNumber
    {
        get => _voucherNumber;
        set { _voucherNumber = value; OnPropertyChanged(); }
    }

    public string VoucherName
    {
        get => _voucherName;
        set { _voucherName = value; OnPropertyChanged(); }
    }

    // ── Footer summary ────────────────────────────────────────────────────────

    private decimal _openAmount;
    private string _mainOpenAmountId = string.Empty;
    private string _additionalStatus = string.Empty;
    private string _customerReceiptNo = string.Empty;

    public decimal OpenAmount
    {
        get => _openAmount;
        set { _openAmount = value; OnPropertyChanged(); }
    }

    public string MainOpenAmountId
    {
        get => _mainOpenAmountId;
        set { _mainOpenAmountId = value; OnPropertyChanged(); }
    }

    public string AdditionalStatus
    {
        get => _additionalStatus;
        set { _additionalStatus = value; OnPropertyChanged(); }
    }

    public string CustomerReceiptNo
    {
        get => _customerReceiptNo;
        set { _customerReceiptNo = value; OnPropertyChanged(); }
    }

    // ── Grid ─────────────────────────────────────────────────────────────────

    public ObservableCollection<VoucherLineItem> LineItems { get; } = new();

    // ── Commands ──────────────────────────────────────────────────────────────

    public ICommand RefreshCommand { get; }
    public ICommand NewCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand CopyCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand FindCommand { get; }
    public ICommand PrintCommand { get; }
    public ICommand PartialPostingCommand { get; }
    public ICommand ReleaseCommand { get; }
    public ICommand CloseCommand { get; }

    public VoucherEntryViewModel()
    {
        SelectedTransferType = TransferTypes[0];
        SelectedTransferPeriod = TransferPeriods[0];
        SelectedTransferStatus = TransferStatuses[0];
        SelectedStatusTo = StatusToOptions[0];
        SelectedSupplierType = SupplierTypes[0];
        IssueDate = DateTime.Today;
        EntryDate = DateTime.Today;
        ExchangeRate = 1.0m;
        VatEditionNote = "Intended for VAT Edition";

        TransferGroups.Add(new TransferGroupNode { DisplayName = "Group: ABCDEFG-ABCDEF", IsSelected = true });
        SelectedTransferGroup = TransferGroups[0];

        RefreshCommand = new RelayCommand(_ => OnRefresh());
        NewCommand = new RelayCommand(_ => OnNew());
        SaveCommand = new RelayCommand(_ => OnSave());
        CopyCommand = new RelayCommand(_ => OnCopy());
        DeleteCommand = new RelayCommand(_ => OnDelete());
        FindCommand = new RelayCommand(_ => OnFind());
        PrintCommand = new RelayCommand(_ => OnPrint());
        PartialPostingCommand = new RelayCommand(_ => OnPartialPosting());
        ReleaseCommand = new RelayCommand(_ => OnRelease());
        CloseCommand = new RelayCommand(_ => OnClose());
    }

    private void OnRefresh() { }
    private void OnNew() { }
    private void OnSave() { }
    private void OnCopy() { }
    private void OnDelete() { }
    private void OnFind() { }
    private void OnPrint() { }
    private void OnPartialPosting() { }
    private void OnRelease() { }
    private void OnClose() { }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

using System.Collections.Generic;
using System.Windows.Input;
using OverlayEngine.Application.Editor;
using OverlayEngine.Application.Interaction;
using OverlayEngine.Application.Widgets;
using OverlayEngine.Application.Widgets.Definitions;
using OverlayEngine.Domain.ValueObjects;
using OverlayEngine.UI.Rendering;
using OverlayEngine.UI.ViewModels.Commands;

namespace OverlayEngine.UI.ViewModels;

public sealed class EditorShellViewModel : ViewModelBase
{
    private readonly OverlayEditor _editor;
    private readonly WidgetCatalog _catalog;

    private bool _isEditMode = true;
    private bool _isCatalogOpen;

    public CanvasViewModel Canvas { get; }
    public RenderPipeline RenderPipeline { get; }
    public WidgetPointerController PointerController { get; }

    public IReadOnlyCollection<IWidgetDefinition> Definitions => _catalog.All;

    public bool IsEditMode
    {
        get => _isEditMode;
        private set
        {
            if (Set(ref _isEditMode, value))
            {
                Raise(nameof(IsCatalogVisible));
                Raise(nameof(IsToolbarVisible));
            }
        }
    }

    public bool IsCatalogOpen
    {
        get => _isCatalogOpen;
        private set
        {
            if (Set(ref _isCatalogOpen, value))
            {
                Raise(nameof(IsCatalogVisible));
            }
        }
    }

    public bool IsToolbarVisible => IsEditMode;
    public bool IsCatalogVisible => IsEditMode && IsCatalogOpen;

    public ICommand ToggleEditModeCommand { get; }
    public ICommand ToggleCatalogCommand { get; }
    public ICommand AddWidgetCommand { get; }

    public EditorShellViewModel(
        OverlayEditor editor,
        WidgetCatalog catalog,
        CanvasViewModel canvas,
        RenderPipeline renderPipeline,
        WidgetPointerController pointerController)
    {
        _editor = editor;
        _catalog = catalog;

        Canvas = canvas;
        RenderPipeline = renderPipeline;
        PointerController = pointerController;

        ToggleEditModeCommand = new RelayCommand(_ => ToggleEditMode());
        ToggleCatalogCommand = new RelayCommand(_ => ToggleCatalog());
        AddWidgetCommand = new RelayCommand<string>(definitionId => AddWidget(definitionId));

        IsEditMode = true;
        IsCatalogOpen = false;
    }

    public void ToggleEditMode()
    {
        IsEditMode = !IsEditMode;

        if (IsEditMode)
            _editor.EnterEdit();
        else
            _editor.EnterView();
    }

    public void ToggleCatalog()
    {
        IsCatalogOpen = !IsCatalogOpen;
    }

    public void AddWidget(string? definitionId)
    {
        if (string.IsNullOrWhiteSpace(definitionId))
            return;

        var widget = _editor.Create(new WidgetDefinitionId(definitionId));
        _editor.Select(widget.Id);
    }
}
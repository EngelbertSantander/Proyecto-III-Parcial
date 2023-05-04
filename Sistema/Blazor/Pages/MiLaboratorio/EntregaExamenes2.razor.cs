﻿using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MiLaboratorio
{
    public partial class EntregaExamenes2
    {
        [Inject] private IExamenServicio examenServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }

        [Parameter] public string IdExamen { get; set; }

        private Examen examen = new Examen();
        protected override async Task OnInitializedAsync()
        {
            examen = await examenServicio.BuscarPorIdAsync(IdExamen);

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que el examen a entregar corresponde a ID:" + examen.IdentidadCliente,
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });
            if (!string.IsNullOrEmpty(result.Value))
            {
                examen.Estado = "Entregado a Cliente";
                examen.RecogidoPorCliente = true;
                await examenServicio.ActualizarAsync(examen);

            }

            navigationManager.NavigateTo("/EntregaExamenes");
        }
    }
}

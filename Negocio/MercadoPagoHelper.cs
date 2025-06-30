using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using Dominio;

namespace Negocio
{
    public static class MercadoPagoHelper
    {
        public static string CrearPreferencia(Pedido pedido)
        {
            // Establecer el AccessToken
            MercadoPagoConfig.AccessToken = System.Configuration.ConfigurationManager.AppSettings["MP_AccessToken"];

            // Crear ítems
            var items = new List<PreferenceItemRequest>();

            foreach (var item in pedido.Items)
            {
                items.Add(new PreferenceItemRequest
                {
                    Title = item.Producto.Nombre,
                    Quantity = item.Cantidad,
                    CurrencyId = "ARS",
                    UnitPrice = item.Precio
                });
            }

            // Configurar URLs de retorno
            var backUrls = new PreferenceBackUrlsRequest
            {
                Success = "https://localhost:44300/PagoExitoso.aspx",
                Failure = "https://localhost:44300/PagoFallido.aspx",
                Pending = "https://localhost:44300/PagoPendiente.aspx"
            };

            // Crear preferencia
            var preferenceRequest = new PreferenceRequest
            {
                Items = items,
                BackUrls = backUrls,
                AutoReturn = "approved" // o "all"
            };

            var client = new PreferenceClient();
            Preference preference = client.Create(preferenceRequest);

            return preference.InitPoint; // URL para redireccionar al checkout
        }
    }
}
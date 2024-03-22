namespace SiaesCliente.Helpers
{
    public static class ErrorLogger
    {
        public static void LogError(Exception ex)
        {
            // Obtén la ruta de la carpeta de logs (puedes ajustarla según tus necesidades)
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            // Crea la carpeta de logs si no existe
            Directory.CreateDirectory(logDirectory);

            // Genera un nombre de archivo único para el log
            string logFileName = $"ErrorLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string logFilePath = Path.Combine(logDirectory, logFileName);

            // Escribe el error en el archivo de log
            using (StreamWriter writer = new StreamWriter(logFilePath))
            {
                writer.WriteLine("Error ocurrido el: " + DateTime.Now);
                writer.WriteLine("Mensaje de error: " + ex.Message);
                writer.WriteLine("Detalles del error: " + ex.ToString());
            }
        }
    }
}

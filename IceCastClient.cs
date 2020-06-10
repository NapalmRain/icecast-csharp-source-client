using System.IO;

namespace IceCastLibrary {
	public class IceCastClient {
		private Libshout icecast;
        private byte[] buff = new byte[ 4096 ];
        private int read;

        /// <summary>
        /// Создаём экземпляр клиента
        /// </summary>
        /// <param name="host">адрес сервера</param>
        /// <param name="port">порт сервера</param>
        /// <param name="pass">пароль для доступа</param>
        /// <param name="stationName">наименование станции</param>
        public IceCastClient (string host, int port, string pass, string stationName) {
            icecast = new Libshout();
            icecast.setProtocol( 0 );
            icecast.setHost( host );
            icecast.setPort( port );
            icecast.setPassword( pass );
            icecast.setFormat( Libshout.FORMAT_MP3 );
            icecast.setPublic( true );
            icecast.setName( stationName );
            icecast.setMount( "/live" );
        }

        public bool open() {
            icecast.open();
            return icecast.isConnected();
        }

        public string GetError() {
            return icecast.GetError();
        }

        public void PlaySong(string fileName) {
            //читаем файл
            BinaryReader reader = new BinaryReader( File.Open( fileName, FileMode.Open ) );
            int total = 0;
            while ( true ) {
                //читаем буфер
                read = reader.Read( buff, 0, buff.Length );
                total = total + read;

                //если прочитан не весь, то передаем
                if ( read > 0 ) {
                    icecast.send( buff, read );    //пауза, синхронизация внутри метода
                } else break;  //уходим
            }
            icecast.close();
        }
	}
}

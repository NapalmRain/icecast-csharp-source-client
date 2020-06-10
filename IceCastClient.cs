using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCastLibrary {
	public class IceCastClient {
		private Libshout icecast;
        private byte[] buff = new byte[ 4096 ];
        private int read;

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
            icecast.open();
        }

        public bool connect() {
            return icecast.isConnected();
        }

        public string GetError() {
            return icecast.GetError();
        }

        public void PlaySong(string fileName) {
            //читаем файл
            BinaryReader reader = new BinaryReader( File.Open( filename, FileMode.Open ) );
            int total = 0;
            while ( true ) {
                //читаем буфер
                read = reader.Read( buff, 0, buff.Length );
                total = total + read;

                Console.WriteLine( "Position:  " + reader.BaseStream.Position );
                //если прочитан не весь, то передаем
                if ( read > 0 ) {
                    icecast.send( buff, read );    //пауза, синхронизация внутри метода
                } else break;  //уходим

            }

            Console.WriteLine( "Done!" );
            Console.ReadKey( true );
            icecast.close();
        }

	}
}

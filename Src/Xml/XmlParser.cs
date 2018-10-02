/*
    This file is part of the Kivu (R) project.
    Copyright (c) 2017-2018 Irene Solutions SL
    Authors: Irene Solutions SL.

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License version 3
    as published by the Free Software Foundation with the addition of the
    following permission added to Section 15 as permitted in Section 7(a):
    FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
    IRENE SOLUTIONS SL. IRENE SOLUTIONS SL DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
    OF THIRD PARTY RIGHTS
    
    This program is distributed in the hope that it will be useful, but
    WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
    or FITNESS FOR A PARTICULAR PURPOSE.
    See the GNU Affero General Public License for more details.
    You should have received a copy of the GNU Affero General Public License
    along with this program; if not, see http://www.gnu.org/licenses or write to
    the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
    Boston, MA, 02110-1301 USA, or download the license from the following URL:
        http://www.irenesolutions.com/terms-of-use.pdf
    
    The interactive user interfaces in modified source and object code versions
    of this program must display Appropriate Legal Notices, as required under
    Section 5 of the GNU Affero General Public License.
    
    You can be released from the requirements of the license by purchasing
    a commercial license. Buying such a license is mandatory as soon as you
    develop commercial activities involving the Kivu software without
    disclosing the source code of your own applications.
    These activities include: offering paid services to customers as an ASP,
    serving Kivu services on the fly in a web application, shipping Kivu
    with a closed source product.
    
    For more information, please contact Irene Solutions SL. at this
    address: info@irenesolutions.com
 */

using System.IO;
using System.Xml.Serialization;

namespace Bce.ExchangeRates.Xml
{


    /// <summary>
    /// Encargado de la serialización y deserialización
    /// de archivos xml.
    /// </summary>
    public class XmlParser
    {

        #region Public Methods

        /// <summary>
        /// Serializa el objeto como xml y lo guarda
        /// en la ruta indicada.
        /// </summary>
        /// <param name="instance">Instancia de objeto a serializar.</param>
        /// <param name="path">Ruta al archivo xml a crear.</param>
        public static void SaveAsXml(object instance, string path)
        {
            XmlSerializer serializer = new XmlSerializer(instance.GetType());

            using (StreamWriter w = new StreamWriter(path))
            {
                serializer.Serialize(w, instance);
            }
        }

        /// <summary>
        /// Serializa el objeto como xml y lo devuelve
        /// como una matriz de bytes.
        /// </summary>
        /// <param name="instance">Instancia de objeto a serializar.</param>
        public static byte[] GetXml(object instance)
        {

            byte[] buff = null;

            XmlSerializer serializer = new XmlSerializer(instance.GetType());

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, instance);
                buff = ms.ToArray();
            }

            return buff;
        }

        /// <summary>
        /// Obtiene una instancia de objeto a partir de un
        /// archivo xml.
        /// </summary>
        /// <param name="path">Ruta al archivo.</param>
        /// <returns>Instancia de tipo T.</returns>
        public static T FromXml<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            if (File.Exists(path))
            {
                using (StreamReader r = new StreamReader(path))
                {
                    return (T)serializer.Deserialize(r);
                }
            }
            else
            {
                throw new FileNotFoundException($"No se encontró el archivo: {path}");
            }
        }

        /// <summary>
        /// Obtiene una instancia de objeto a partir de una
        /// matriz de bytes.
        /// </summary>
        /// <param name="buff">Matriz de bytes que contiene los datos xml.</param>
        /// <returns>Instancia de tipo T.</returns>
        public static T FromXml<T>(byte[] buff)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            MemoryStream ms = new MemoryStream(buff);
         
            using (StreamReader r = new StreamReader(ms))
            {
                return (T)serializer.Deserialize(r);
            }
          
        }

        #endregion

    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Web;

namespace GetSiteAccessIP.Models
{
 
        [Serializable]
        public class CustomException :
            Exception,
            ISerializable
        {
            /// <summary>
            /// エラー種別
            /// </summary>
            private CustomExceptionType type;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public CustomException() : base()
            {
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="type">エラー種別</param>
            public CustomException(CustomExceptionType type) : base()
            {
                this.type = type;
            }

            /// <summary>エラー種別</summary>
            public enum CustomExceptionType
            {
                /// <summary>不明</summary>
                None,

                /// <summary>セッションタイムアウト</summary>
                SeesionTimeOut
            }

            /// <summary>エラー種別</summary>
            public CustomExceptionType ErrorType
            {
                get { return this.type; }
            }

            /// <summary>
            /// GetObjectData
            /// </summary>
            /// <param name="info">
            /// SerializationInfo</param>
            /// <param name="context">
            /// StreamingContext</param>
            [SecurityCritical]
            public override void GetObjectData(
                SerializationInfo info,
                StreamingContext context)
            {
                base.GetObjectData(info, context);
            }
        }
    }

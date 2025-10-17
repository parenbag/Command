using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandTask
{
    public interface Click
    {
        Action Execute(Vector3 clickPosition);
    }
}

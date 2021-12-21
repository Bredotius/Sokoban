using System.Collections.Generic;

namespace Sokoban
{
    public class Levels
    {
        private const string map1 = @"
#####
#p#O#
# o+#
#####";
        private const string map2 = @"
  ##### 
###   # 
#+po  # 
### o+# 
#+##o # 
# # + ##
#o Ooo+#
#   +  #
########";
        private const string map3 = @"
#############
#     o     #
#     o     #
# o    #    #
#  p   M   o#
#     o     #
#############";
        private const string map4 = @"
#############
#   *   #  +#
# o  #+##* ##
# #*o @ o   #
#  p  + ## ##
#@ # * M   *#
#############";

        public List<string> Maps = new List<string>() { map1, map2, map3, map4 };
    }
}
